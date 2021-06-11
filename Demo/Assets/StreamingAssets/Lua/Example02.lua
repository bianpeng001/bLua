local GameObject = UnityEngine.GameObject
local TrailRenderer = UnityEngine.TrailRenderer

local Example02 = bLua.Example02

local LuaBehaviour = require("Core/LuaBehaviour")
local Math = require("Core/Math")

local Input = UnityEngine.Input
local Time = UnityEngine.Time
local Vector3 = Math.Vector3

local ACT_MOVE <const> = 1
local ACT_SHOOT <const> = 2
local _G <const> = -9.8

local module = LuaBehaviour.CreateModule()

local _example02 = nil
local _deltaTime = 0
local _unitsMgr
local _bulletsMgr
local _pidSeed = 1000

local Player = {}
Player.__index = Player

function Player.New()
    _pidSeed = _pidSeed + 1
    local obj =
    {
        pid = _pidSeed,
        position = { 0, 0, 0, },
        hp = 100,
        speed = 1.5,
        action = 0,
        gameObject = nil,
        
        shoot_cd = 0,
        bullet_count = 3,
    }
    setmetatable(obj, Player)
    return obj
end

function Player:SetPosition(pos)
    self.position[1] = pos[1]
    self.position[2] = pos[2]
    self.position[3] = pos[3]

    if self.transform then
        self.transform.localPosition = pos
    end
end

function Player:Action()
    if self.action == ACT_MOVE then
        if self.time < 1 then
            self.time = self.time + _deltaTime * self.timeRactor
            local pos = Vector3.Add(self.startPosition, Vector3.Scale(self.deltaPosition, self.time))
            self:SetPosition(pos)
        else
            self.action = ACT_SHOOT
        end
    elseif self.action == ACT_SHOOT then
        self.shoot_cd = self.shoot_cd - _deltaTime
        if self.shoot_cd < 0 then
            self.shoot_cd = 0.5

            self.bullet_count = self.bullet_count - 1
            if self.bullet_count < 0 then
                self.hp = -1
            end

            local bullet = _bulletsMgr:NewBullet()
            local p = Vector3.Add(self.position, { 0, 1, 0 })
            local delta = Vector3.Sub({ 0, 2, 0 }, p)
            Vector3.Set(bullet.startPosition, p[1], p[2], p[3])
            bullet.transform.localPosition = p

            delta[2] = delta[2] - 0.5 * _G
            Vector3.Set(bullet.v0, delta[1], delta[2], delta[3])
        end
    end
end

local UnitsMgr = {}
UnitsMgr.__index = UnitsMgr

function UnitsMgr.New()
    local obj = {
        units = {},
        deads = {},
    }
    setmetatable(obj, UnitsMgr)
    return obj
end

function UnitsMgr:Add(p)
    self.units[p.pid] = p
end

local BulletsMgr = {}
BulletsMgr.__index = BulletsMgr

function BulletsMgr.New()
    local obj = {
        freeList = {},
        flyList = {},
        fly2List = {},
        template = nil,
    }
    setmetatable(obj, BulletsMgr)
    return obj
end

function BulletsMgr:NewBullet()
    local obj
    local n = #self.freeList

    if n > 0 then
        obj = self.freeList[n]
        self.freeList[n] = nil
        obj.time = 0
    else
        obj =
        {
            startPosition = { 0, 0, 0, },
            v0 = { 0, 0, 0, },
            time = 0,
            timeScale = 1.0,
            gameObject = self.template:Clone(),
        }
        obj.transform = obj.gameObject.transform
        obj.transform.parent = nil
        obj.transform.localPosition = Vector3.zero

        obj.trailRenderer = cast2type(
            obj.gameObject:GetComponent2(typeof(TrailRenderer)),
            TrailRenderer)
    end

    obj.gameObject:SetActive(true)
    table.insert(self.flyList, obj)
    return obj
end

function BulletsMgr:OnUpdate()
    local flyList = self.flyList
    self.flyList = self.fly2List
    self.fly2List = flyList

    for i = 1, #flyList do
        local obj = flyList[i]
        flyList[i] = nil

        obj.time = obj.time + _deltaTime * obj.timeScale
        if obj.time < 1 then
            local pos = Vector3.Add(obj.startPosition, Vector3.Mul(obj.v0, obj.time))
            pos[2] = pos[2] + 0.5 * _G * obj.time * obj.time
            obj.transform.localPosition = pos
            table.insert(self.flyList, obj)
        else
            obj.trailRenderer:Clear()
            obj.gameObject:SetActive(false)
            table.insert(self.freeList, obj)
        end
    end
end

_unitsMgr = UnitsMgr.New()
_bulletsMgr = BulletsMgr.New()

function module.Awake()
    print('gameObject:', module.gameObject)
    print('name:', module.name)
    print(module.luaBehaviour, getmetatable(module.luaBehaviour).class)
    _example02 = cast2type(module.luaBehaviour, bLua.Example02)
    print('Awake', Time.time, Time.deltaTime)

    module.unitPrefab = { GameObject.Find("Res/Unit01") }
    _bulletsMgr.template = GameObject.Find("Res/Bullet01")
end

local function CreatePlayer()
    local pos = _example02:GetFloorPoint()

    local obj = module.unitPrefab[1]:Clone()
    obj.name = 'Player01'
    local tr = obj.transform
    tr.parent = nil

    local p = Player.New()
    p.gameObject = obj
    p.transform = tr
    _unitsMgr:Add(p)

    p:SetPosition(pos)

    p.action = ACT_MOVE
    p.time = 0
    p.startPosition = Vector3.Clone(pos)
    p.deltaPosition = Example02.GetDeltaPosition(pos, Vector3.zero, 3.0)
    p.timeRactor = 1/ 3.0
    p.gameObject:LookAt(Vector3.zero)
end

local _tickTime = 0
local function OnTick()
    _tickTime = _tickTime + Time.deltaTime
    if _tickTime < 0.2 then
        return
    end
    _tickTime = 0

end

local function OnUpdate()
    _bulletsMgr:OnUpdate()

    local n = 0
    local deads = _unitsMgr.deads
    for pid, v in pairs(_unitsMgr.units) do
        if v.hp < 0 then
            n = n + 1
            deads[n] = pid
        else
            v:Action()
        end
    end

    if n > 0 then
        for i = 1, n do
            local pid = deads[i]
            local unit = _unitsMgr.units[pid]
            if unit.gameObject then
                GameObject.Destroy2(unit.gameObject)
                unit.gameObject = nil
            end
            _unitsMgr.units[pid] = nil
            deads[i] = nil
        end
    end
end

function module.Update()
    if Input.GetMouseButtonUp(0) then
        local pos = Input.mousePosition
        print('ButtonUp, go =', module.gameObject, ', pos =', table.unpack(pos))

        CreatePlayer()
    end

    _deltaTime = Time.deltaTime
    OnTick()
    OnUpdate()
end

return module


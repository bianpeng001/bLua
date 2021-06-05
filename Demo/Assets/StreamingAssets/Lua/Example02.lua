local GameObject = UnityEngine.GameObject

local LuaBehaviour = require("Core/LuaBehaviour")
local Math = require("Core/Math")

local Input = UnityEngine.Input
local Time = UnityEngine.Time
local Vector3 = Math.Vector3

local module = LuaBehaviour.CreateModule()
local _example02
local _deltaTime

local ACT_MOVE <const> = 1
local ACT_SHOOT <const> = 2

local Player = {}
Player.__index = Player

local _pidSeed = 1000

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
            self.time = self.time + _deltaTime / 5
            local pos = Vector3.Add(self.startPosition, Vector3.Scale(self.deltaPosition, self.time))
            self:SetPosition(pos)
        else
            self.action = ACT_SHOOT
        end
    elseif self.action == ACT_SHOOT then
        self.hp = self.hp - 1
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

local _unitsMgr = UnitsMgr.New()

function module.Awake()
    print('gameObject:', module.gameObject)
    print('name:', module.name)
    print(module.luaBehaviour, getmetatable(module.luaBehaviour).class)
    _example02 = cast2type(module.luaBehaviour, bLua.Example02)
    print('Awake', Time.time, Time.deltaTime)

    module.unitPrefab = { GameObject.Find('Res/Unit01') }
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
    p.startPosition = pos
    p.deltaPosition = { 0, 0, -5 }
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
    local deads = _unitsMgr.deads
    for pid, v in pairs(_unitsMgr.units) do
        if v.hp < 0 then
            table.insert(deads, pid)
        else
            v:Action()
        end
    end

    if #deads > 0 then
        for i = 1, #deads do
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


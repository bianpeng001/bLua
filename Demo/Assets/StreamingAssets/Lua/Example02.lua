local GameObject = UnityEngine.GameObject

local LuaBehaviour = require("Core/LuaBehaviour")

local Input = UnityEngine.Input
local Time = UnityEngine.Time

local module = LuaBehaviour.CreateModule()


local Player = {}
Player.__index = Player

function Player.New(pid)
    local obj =
    {
        pid = pid,
        position = { 1, 0, 1, },
        gameObject = {},
    }
    setmetatable(obj, Player)
    return obj
end

local UnitsMgr = {}
UnitsMgr.__index = UnitsMgr

function UnitsMgr.New()
    local obj = {}
    return obj
end

function module.Awake()
    print('gameObject:', module.gameObject)
    print('name:', module.name)
    print('Awake', Time.time, Time.deltaTime)

    module.unit01Prefab = GameObject.Find('Res/Unit01')

    local obj = module.unit01Prefab:Clone()
    obj.name = 'Player01'
    local tr = obj.transform
    tr.parent = nil
    tr.localPosition = { 1, 0, 1, }

    local p = Player.New(1001)
    p.gameObject = obj
end

function module.Update()
    if Input.GetMouseButtonUp(0) then
        local pos = Input.mousePosition
        print('ButtonUp, go =', module.gameObject, ', pos =', table.unpack(pos))
    end
end

return module


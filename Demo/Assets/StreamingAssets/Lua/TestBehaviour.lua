local Math = require("Core/Math")
local LuaBehaviour = require("Core/LuaBehaviour")

local Time = UnityEngine.Time
local Input = UnityEngine.Input

local module = LuaBehaviour.CreateModule()

function module.Awake()
    print('gameObject:', module.gameObject, module.gameObject:ToString())
    print(module.luaBehaviour, type(module.luaBehaviour), module.luaBehaviour ~= nil)
    print('luaBehaviour:', module.luaBehaviour, module.luaBehaviour:ToString())
    print('path:', module.path)
    print('name:', module.name)
    print('enabled:', module.enabled)
    module.enabled = true

    print('Awake', Time.time, Time.deltaTime)

    module.transform = module.gameObject.transform
    
end

local angle = 0
function module.Update()
    module.transform.localRotation = Math.Quaternion.AngleAxis(angle, 0, 1, 0)
    angle = angle + math.pi / 180

    if Input.GetMouseButtonUp(0) then
        local pos = Input.mousePosition
        print('ButtonUp, go =', module.gameObject, ', pos =', table.unpack(pos))
    end
end

function module.OnDestroy()
    print('OnDestroy')
end

return module


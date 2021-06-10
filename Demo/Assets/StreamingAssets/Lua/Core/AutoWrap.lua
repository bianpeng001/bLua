
local rawset = rawset
local rawget = rawget
local setmetatable = setmetatable

local RegisterUnityMethod = RegisterUnityMethod or function(class_id, methodName)
    local methodId = 101
    print('RegisterUnityMethod', class_id, methodName, '->', methodId)
    return methodId
end

local RegisterUnityClass = RegisterUnityClass or function(className, class, class_id)
    print('RegisterUnityClass', className)
end

local CallUnityMethod = CallUnityMethod or function(methodId, ...)
    print('CallUnityMethod', methodId, ...)
end

local CollectUnityHandle = CollectUnityHandle or function(obj)
    print('CollectUnityHandle')
end

local function MakeIndexFunction(class)
    local className = class.class
    local class_id = class[1]
    local _cache = class._cache

    return function(obj, methodName)
        local entry = rawget(_cache, methodName)
        if not entry then
            local methodId = RegisterUnityMethod(class_id, methodName)
            if methodId then
                local method = function(...)
                    return CallUnityMethod(methodId, ...)
                end
                entry = { 1, method, methodId, }
                rawset(class, methodName, method)
            else
                local get_methodId = RegisterUnityMethod(class_id, 'get_' .. methodName)
                local set_methodId = RegisterUnityMethod(class_id, 'set_' .. methodName)
                entry = { 2, get_methodId, set_methodId, }
                rawset(_cache, methodName, entry)
            end
        end

        local type = entry[1]
        if type == 1 then
            return entry[2]
        elseif type == 2 then

            return CallUnityMethod(entry[2], obj)
        else
            print('errored')
            return nil
        end
    end
end

local function MakeNewIndexFunction(class)
    local className = class.class
    local class_id = class[1]
    local _cache = class._cache

    return function(obj, methodName, value)
        local entry = rawget(_cache, methodName)
        if not entry then
            local get_methodId = RegisterUnityMethod(class_id, 'get_' .. methodName)
            local set_methodId = RegisterUnityMethod(class_id, 'set_' .. methodName)
            entry = { 2, get_methodId, set_methodId, }
            rawset(_cache, methodName, entry)
        end
        
        CallUnityMethod(entry[3], obj, value)
    end
end

local AutoWrap = {}

local _class_id_seed = 0

function AutoWrap.DefineClass(class)
    class._cache = {}

    _class_id_seed = _class_id_seed + 1
    local class_id = _class_id_seed
    class[1] = class_id
    local className = class.class

    local indexFunc = MakeIndexFunction(class)

    class.__index = indexFunc
    class.__newindex = MakeNewIndexFunction(class)

    class.__gc = CollectUnityHandle

    class.__tostring = function(obj)
        return string.format('%s@%d', className, obj[1])
    end

    local mt = { __index = indexFunc }
    setmetatable(class, mt)
    
    RegisterUnityClass(className, class_id, class)

    return class
end

function AutoWrap.Test1()
    local GameObject = AutoWrap.DefineClass({ class='UnityEngine.GameObject' })
    GameObject.Hello('hello', 1234)
    GameObject.Hello('hello', 5678)
    GameObject.Greet('greet', 1234)
    
    local go = { [1]=0x1234 }
    setmetatable(go, GameObject)
    go:Speek("hahaha", 1234)
end

function AutoWrap.Test2()
    local Example = AutoWrap.DefineClass({ class='bLua.Example' })
    local result
    result = Example.Add(1, 2)
    print(result)
    result = Example.Add(11, 22)
    print(result)
    result = Example.Add(111, 222)
    print(result)
    result = Example.Add(111, 222, 333)
    print(result)
end

function AutoWrap.Test3()
    local Example = AutoWrap.DefineClass({ class='bLua.Example' })

    print('Example', Example)
    local e = Example.GetInstance()
    print('Example.Instance', e, e[1])

    e:SayHello('SayHello: 111111')

    print("name:", e:get_Name())
    print("name:", e.Name)

    e.Hp = 1234
    print('hp:', e.Hp)

    local mb = cast2type(e, UnityEngine.MonoBehaviour)
    print(mb, mb:ToString())

    e = nil
    collectgarbage('collect')
end


return AutoWrap





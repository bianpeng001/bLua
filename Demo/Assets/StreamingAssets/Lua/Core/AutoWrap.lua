--[[
Copyright 2021 边蓬(bianpeng001@163.com)

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
]]--


local rawset = rawset
local rawget = rawget
local setmetatable = setmetatable

local RegisterUnityMethod = RegisterUnityMethod or function(class_id, methodName)
    local methodId = 101
    print('RegisterUnityMethod', class_id, methodName, '->', methodId)
    return methodId
end

local RegisterUnityClass = RegisterUnityClass or function(className, class)
    print('RegisterUnityClass', className)
end

local CallUnityMethod = CallUnityMethod or function(methodId, ...)
    print('CallUnityMethod', methodId, ...)
end

local CollectUnityObject = CollectUnityObject or function(obj)
    print('CollectUnityObject')
end

local UnityObject2ObjIndex = UnityObject2ObjIndex or function(obj)
    print('UnityObject2ObjIndex')
end

local function MakeIndexFunction(class)
    local className = class.class
    local class_id = class[1]
    local _cache = class._cache

    return function(obj, methodName)
        local type

        local entry = rawget(_cache, methodName)
        if not entry then
            local methodId = RegisterUnityMethod(class_id, methodName)
            if methodId then
                local method = function(...)
                    return CallUnityMethod(methodId, ...)
                end
                type = 1
                entry = { 1, method, methodId, }
                rawset(class, methodName, method)
            else
                local get_methodId = RegisterUnityMethod(class_id, 'get_' .. methodName)
                local set_methodId = RegisterUnityMethod(class_id, 'set_' .. methodName)
                if get_methodId or set_methodId then
                    type = 2
                    entry = { 2, get_methodId, set_methodId, }
                    rawset(_cache, methodName, entry)
                end
            end
        else
            type = entry[1]
        end

        if type == 1 then
            return entry[2]
        elseif type == 2 then

            return CallUnityMethod(entry[2], obj)
        end

        return nil
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

function AutoWrap.DefineClass(class)
    class._cache = {}

    local className = class.class
    local class_id = RegisterUnityClass(className, class)
    class[1] = class_id

    local indexFunc = MakeIndexFunction(class)

    class.__index = indexFunc
    class.__newindex = MakeNewIndexFunction(class)

    class.__gc = CollectUnityObject

    class.__tostring = function(obj)
        return string.format('%s@%d', className, UnityObject2ObjIndex(obj))
    end

    local mt = { __index = indexFunc }
    setmetatable(class, mt)
    
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

function AutoWrap.ToTable(coll)
	local result = {}

	local n = coll.Count
    for i = 1, n do
        result[i] = coll:get_Item(i - 1)
    end


	return result
end


return AutoWrap





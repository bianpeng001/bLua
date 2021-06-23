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

local print = print
local rawget = rawget
local rawset = rawset

local DataSetWriteField = DataSetWriteField or function (t, k, v)
    print('DataSetWriteField', t, k, v)
end

local DataSetMT = {}

function DataSetMT.__index(obj, k)
    return rawget(obj[1], k)
end

function DataSetMT.__newindex(obj, k, v)
    rawset(obj[1], k, v)
    DataSetWriteField(obj, k, v)
end

local DataSet = {}

function DataSet.New(store, bind)
    local obj =
    {
        [1] = store or {},
        [2] = bind,
    }
    setmetatable(obj, DataSetMT)
    return obj
end

local function Test1()
    local A = {}
    function A.__index(t, k)
        print('read', k)
    end
    function A.__newindex(t, k, v)
        print('write', k, v)
        rawset(t, k, v)
    end

    local obj = {}
    setmetatable(obj, A)

    print(obj.aa)
    obj.aa = 1234

    print(obj.aa)
    obj.aa = 4321
end

local function Test2()
    local a = DataSet.New({
        name = 'hello',
        number = 1234,
    })
    print(a.number)
    a.number = 4321
    print(a.number)
    a.number = 5678
    print(a.number)
end


return DataSet


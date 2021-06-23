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


local LuaBehaviour = require("Core/LuaBehaviour")
local DataSet = require("Core/DataSet")

local module = LuaBehaviour.CreateModule()

function module.Awake()
    print('example 06')
    module.dataset = DataSet.New({
        name = '试试',
    })
end

function module.Test1()
    local dataset = module.dataset
    dataset.name = '试试就试试'
end

return module


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

local setmetatable = setmetatable
local rawget = rawget
local rawset = rawset

local LuaBehaviour = {}

function LuaBehaviour.CreateModule()
    local _cache = {}
    local obj = {
        __index = function(tbl, key)
            local prop = rawget(_cache, key)
            if prop then
                if prop[1] then
                    return prop[1]()
                end
            else
                return rawget(tbl, key)
            end
        end,
        __newindex = function(tbl, key, value)
            local prop = rawget(_cache, key)
            if prop then
                if prop[2] then
                    prop[2](value)
                end
            else
                rawset(tbl, key, value)
            end
        end,
        CreateProperty = function(name, getter, setter)
            _cache[name] = { getter, setter }
            return 0
        end,
    }

    setmetatable(obj, obj)
    return obj
end

return LuaBehaviour


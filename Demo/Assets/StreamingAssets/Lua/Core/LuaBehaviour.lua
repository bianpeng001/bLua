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


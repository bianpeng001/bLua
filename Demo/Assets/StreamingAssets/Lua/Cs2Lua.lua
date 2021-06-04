
local module = {}

local _cache = {}

function module.SayHello(...)
    print('cs2lua', ...)
end

function module.SendMessage(msgId, ...)
    local fun = _cache[msgId]
    if fun then
        fun(...)
    end
end

function module.RegisterMessage(message, msgId)
    _cache[msgId] = module[message]
end

return module


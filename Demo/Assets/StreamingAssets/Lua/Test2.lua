
local module = {}

function module.SayHello()
    print('hello')
    return 123
end

function module.Add(a, b)
    print(string.format("%d + %d = %d", a, b, a + b))
    return a + b
end

module.x = 111

print('Test2')

return module

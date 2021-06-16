local AutoWrap = require("Core/AutoWrap")

local GameObject = UnityEngine.GameObject

local function Test1()
    local obj = GameObject.Find("Floor/Hero")
    print(obj)
    local tr = obj:get_transform()
    print(tr)
    
    local p1 = tr:get_localPosition()
    print(table.unpack(p1))
    tr:set_localPosition({3, 2, 1})
    print(tr:get_localPosition())
    tr:set_localPosition({1, 2, 1})
    print(tr:get_localPosition())

    tr.localPosition = {4, 4, 4}
    local p = tr.localPosition
    print(p)
    print(p, table.unpack(p))

    local tr2 = obj.transform
    print(tr2)
    tr2.localPosition = {4, 1, 4}
    print(table.unpack(tr2.localPosition))
end

local function Test2()
    local Example = bLua.Example

    print('Example', Example)
    local e = Example.GetInstance()
    print('Example.Instance', e, e[1])

    Example.Add(1, 2)
    Example.Add(1, 2, 3)

    e:SayHello('1: hello hello')
    e:SayHello('2:', 'hello hello')

    print("name:", e:get_Name())
    print("name:", e.Name)

    e.Hp = 1234
    print('hp:', e.Hp)
    e.Hp = 4321
    print('hp:', e.Hp)

    local mb = cast2type(e, UnityEngine.MonoBehaviour)
    print(mb, mb:ToString())

    e = nil
    collectgarbage('collect')
end

local function Test3()
    local Example = bLua.Example
    local obj = GameObject.Find("Example")
    print(obj)
    print(obj.name)
    print(obj:ToString())
    
    local exampleType = typeof(Example)
    print(exampleType, exampleType.FullName)
    local example = obj:GetComponent2(exampleType)
    print(example)
    print(example:ToString())

    

end

local function Test4()
    local Example = bLua.Example

    Example.set_Time(1122)
    print(Example.get_Time())
    print(Example.Time)
    
    Example.Time = 2211
    print(Example.Time)
end

local function Test5()
    local LuaDelegate = bLua.LuaDelegate

    local Example = bLua.Example
    local dele = Example.GetDelegate()
    print(dele)
    local sum = dele(1, 2, 3)
    print('sum', sum)
end

local function Test6()
    local LuaBehaviour = require('Core/LuaBehaviour')
    local module = LuaBehaviour.CreateModule()
    module.CreateProperty('name', function () return 'this is name' end)

    print('module.name', module.name)
end

local function Test7()
    print('test array, list')
    local Example = bLua.Example

    print('test int[]')
    local a = Example.GetIntArray()
    a = AutoWrap.ToTable(a)
    print('len', #a)
    print(table.unpack(a))

    print('test List<int>')
    local b = Example.GetIntList()
    b = AutoWrap.ToTable(b)
    print('len', #b)
    print(table.unpack(b))

    print('test string[]')
    local c = Example.GetStringArray()
    c = AutoWrap.ToTable(c)
    print('len', #c)
    print(table.unpack(c))
end

local function Test8()
    print('test CreateProperty')
    local LuaBehaviour = require("Core/LuaBehaviour")
    local module = LuaBehaviour.CreateModule()
    module.CreateProperty('name', function() return 'xxxx' end, function (value) print(value) end)
    print(module.name)
    module.name = 'yyyy'
end

Test1()
Test2()
Test3()
Test4()
Test5()
Test6()
Test7()
Test8()

collectgarbage('collect')




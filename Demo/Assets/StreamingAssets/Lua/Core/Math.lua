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


local sin = math.sin
local cos = math.cos
local sqrt = math.sqrt
local setmetatable = setmetatable

local module = {}

local Quaternion = {}
module.Quaternion = Quaternion
Quaternion.__index = Quaternion

function Quaternion.New(x, y, z ,w)
    local q = { x, y, z, w }
    setmetatable(q, Quaternion)
    return q
end

function Quaternion.Identity()
    return Quaternion.New(0, 0, 0, 1)
end

function Quaternion.AngleAxis(angle, x, y, z, result)
    result = result or { 0, 0, 0, 0 }

    angle = angle * 0.5
    local s = sin(angle)
    result[1], result[2], result[3], result[4] = s * x, s * y, s * z, cos(angle)

    return result
end

local Vector3 = {}
module.Vector3 = Vector3
Vector3.__index = Vector3

function Vector3.New(x, y, z)
    local v = { x, y, z }
    setmetatable(v, Vector3)
    return v
end

function Vector3:Clone()
    return { self[1], self[2], self[3] }
end

function Vector3.SetXYZ(v, x, y, z)
    v[1] = x
    v[2] = y
    v[3] = z
end
Vector3.Set = Vector3.SetXYZ

function Vector3.SetXZ(v, x, z)
    v[1] = x
    v[3] = z
end

function Vector3.SetV(v, v2)
    v[1] = v2[1]
    v[2] = v2[2]
    v[3] = v2[3]
end

function Vector3:Length()
    return sqrt(self:SqrLength())
end

function Vector3:SqrLength()
    return Vector3.Dot(self, self)
end

function Vector3.Add(a, b, result)
    result = result or { 0, 0, 0 }
    result[1], result[2], result[3] = a[1] + b[1], a[2] + b[2], a[3] + b[3]
    return result
end

function Vector3.Sub(a, b, result)
    result = result or { 0, 0, 0 }
    result[1], result[2], result[3] = a[1] - b[1], a[2] - b[2], a[3] - b[3]
    return result
end

function Vector3.Mul(v, s, result)
    result = result or { 0, 0, 0 }
    result[1], result[2], result[3] =  v[1] * s, v[2] * s, v[3] * s 
    return result
end
Vector3.Scale = Vector3.Mul

function Vector3.Dot(a, b)
    return a[1] * b[1] + a[2] * b[2] + a[3] * b[3]
end

function Vector3.Cross(a, b, result)
    result = result or { 0, 0, 0 }

    result[1] = a[2] * b[3] - a[3] * b[2]
    result[2] = a[3] * b[1] - a[1] * b[3]
    result[3] = a[1] * b[2] - a[2] * b[1]

    return result
end

function Vector3.Lerp(a, b, factor, result)
    result = result or { 0, 0, 0 }
    return result
end

function Vector3.Distance(a, b)
    local x = a[1] - b[1]
    local y = a[2] - b[2]
    local z = a[3] - b[3]

    return sqrt( x*x + y*y + z*z )
end

Vector3.zero = Vector3.New(0, 0, 0)

local Vector2 = {}
module.Vector2 = Vector2
Vector2.__index = Vector2

function Vector2.New(x, y)
    local v = { x, y }
    setmetatable(v, Vector2)
    return v
end

function Vector2:Length()
    return sqrt(self:SqrLength())
end

function Vector2:SqrLength()
    return self[1]*self[1] + self[2]*self[2]
end

Vector2.zero = Vector2.New(0, 0)

local Ray = {}
module.Ray = Ray

function Ray.New(x, y, z, dx, dy, dz)
    return { x, y, z, dx, dy, dz }
end

function Ray:GetPoint(d, result)
    result = result or { 0, 0, 0 }
    result[1], result[2], result[3] = self.x + d * self.dx , self.y + d * self.dy, self.z + d * self.dz
    return result
end

local Plane = {}
module.Plane = Plane

function Plane.New(x, y, z, d)
    return { x, y, z, d }
end

return module


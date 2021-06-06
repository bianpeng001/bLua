
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

function Quaternion.AngleAxis(angle, x, y, z)
    angle = angle * 0.5
    local s = sin(angle)
    return { s * x, s * y, s * z, cos(angle) }
end

local Vector3 = {}
module.Vector3 = Vector3
Vector3.__index = Vector3

function Vector3.New(x, y, z)
    local v = { x, y, z }
    setmetatable(v, Vector3)
    return v
end

Vector3.zero = Vector3.New(0, 0, 0)

function Vector3:Length()
    return sqrt(self:SqrLength())
end

function Vector3:SqrLength()
    return Vector3.Dot(self, self)
end

function Vector3.Add(a, b)
    return { a[1] + b[1], a[2] + b[2], a[3] + b[3] }
end

function Vector3.Sub(a, b)
    return { a[1] - b[1], a[2] - b[2], a[3] - b[3] }
end

function Vector3.Scale(v, s)
    return { v[1] * s, v[2] * s, v[3] * s }
end

function Vector3.Dot(a, b)
    return a[1] * b[1] + a[2] * b[2] + a[3] * b[3]
end

function Vector3.Cross(a, b)
    return { a[2] * b[3] - a[3] * b[2], a[3] * b[1] - a[1] * b[3], a[1] * b[2] - a[2] * b[1] }
end

function Vector3.Lerp(a, b, f)

end

function Vector3.Distance(a, b)

end

local Vector2 = {}
module.Vector2 = Vector2
Vector2.__index = Vector2

function Vector2.New(x, y)
    local v = {x, y}
    setmetatable(v, Vector2)
    return v
end

function Vector2:Length()

end

function Vector2:SqrLength()

end

local Ray = {}
module.Ray = Ray

function Ray.New(x, y, z, dx, dy, dz)
    return { x, y, z, dx, dy, dz }
end

function Ray:GetPoint(d)
    return { x + d * dx , y + d * dy, z + z * dz }
end

local Plane = {}
module.Plane = Plane

function Plane.New(x, y, z, d)
    return { x, y, z, d }
end

return module


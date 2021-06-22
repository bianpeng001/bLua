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

local GameObject = UnityEngine.GameObject
local Time = UnityEngine.Time
local TrailRenderer = UnityEngine.TrailRenderer

local LuaBehaviour = require("Core/LuaBehaviour")
local Math = require("Core/Math")

local print = print
local Vector3 = Math.Vector3
local Quaternion = Math.Quaternion

local _moveSystem
local _deltaTime
local _unitsMgr
local _unitPrefab
local _towerMgr = {}

local _x0 = -8 + 0.5
local _z0 = -10 + 0.5

local _ring

local _unit_pid_seed = 0

local Unit = {}
Unit.__index = Unit

function Unit.New()
	_unit_pid_seed = _unit_pid_seed + 1

	local obj =
	{
		pid = _unit_pid_seed,
		hp = 100,
		speed = 2,

		x = 0,
		z = 0,
		position = { 0, 0, 0 },

		state = 1,
		ai = { },
	}
	setmetatable(obj, Unit)
	return obj
end

local function GetWorldXZ(x, z)
	return x + _x0, z + _z0
end

function Unit:SetXZ(x, z)
	self.x = x
	self.z = z
	local x1, z1 = GetWorldXZ(x, z)
	Vector3.SetXZ(self.position, x1, z1)
	if self.transform then
		self.transform.localPosition = self.position
	end
end

function Unit:OnIdle()
	local path

	path = _moveSystem:FindPath(self.x, self.z, self.x < 8 and 7 or 9, self.z + 16)
	if not path then
		print('noway', self.x, self.z)
		self.state = 3
		return
	end


	local ai = self.ai
	ai.path = path
	ai.index = 0
	ai.time = 0

	self:StartMove()
	self.state = 2
end

function Unit:StartMove()
	local ai = self.ai
	local path = ai.path
	local index = ai.index

	ai.x0 = path:get_Item(index)
	ai.z0 = path:get_Item(index+1)

	local x1 = path:get_Item(index+2)
	local z1 = path:get_Item(index+3)

	ai.dx = x1 - ai.x0
	ai.dz = z1 - ai.z0

	ai.rec_time = math.sqrt(ai.dx*ai.dx+ai.dz*ai.dz) / self.speed
	ai.rec_time = 1.0 / ai.rec_time

	if self.gameObject then
		local x2, z2 = GetWorldXZ(x1, z1)
		self.gameObject:LookAt({ x2, 0, z2 })
	end
end

function Unit:OnMove()
	local ai = self.ai

	ai.time = ai.time + _deltaTime * ai.rec_time

	if ai.time <= 1.0 then
		local x = ai.x0 + ai.dx * ai.time
		local z = ai.z0 + ai.dz * ai.time
		self:SetXZ(x, z)
	else
		ai.time = ai.time - 1.0
		ai.index = ai.index + 2
		local count = ai.path.Count
		if ai.index <= count - 4 then
			self:StartMove()
		else
			self.state = 3
		end
	end
end

function Unit:OnAttack()
	_unitsMgr:Remove(self)
	GameObject.Destroy(self.gameObject)
	self.gameObject = nil
end

Unit.actions = { Unit.OnIdle, Unit.OnMove, Unit.OnAttack }

function Unit:LoadModel()
	self.gameObject = _unitPrefab[1]:Clone()
	self.gameObject.name = string.format('unit_%d', self.pid)
	self.transform = self.gameObject.transform
	self.transform.parent = nil
	self:SetXZ(self.x, self.z)
end

function Unit:Update()
	local cb

	cb = self.actions[self.state]
	if cb then
		cb(self)
	end
end

local UnitsMgr = {}
UnitsMgr.__index = UnitsMgr

function UnitsMgr.New()
	local obj =
	{
		units = {},
		count = 0,
	}
	setmetatable(obj, UnitsMgr)
	return obj
end

function UnitsMgr:Add(unit)
	self.count = self.count + 1
	self.units[unit.pid] = unit
end

function UnitsMgr:Remove(unit)
	self.count = self.count - 1
	self.units[unit.pid] = nil
end

function UnitsMgr:Update(deltaTime)
	for pid, unit in pairs(self.units) do
		unit:Update()
	end
end

local Tower = {}
Tower.__index = Tower

function Tower.New()
	local obj =
	{
		x = 0,
		z = 0,
		time = 0,
	}
	setmetatable(obj, Tower)
	return obj
end

function Tower:Update()
	local unit

	self.time = self.time + _deltaTime
	if self.time < 2 then
		goto end_of_update
	end
	self.time = 0

	unit = Unit.New()
	unit:SetXZ(math.random(0, 15), self.z + 1)
	unit:LoadModel()

	_unitsMgr:Add(unit)

::end_of_update::

end

local module = LuaBehaviour.CreateModule()

function module.Awake()
	local path

	_moveSystem = module.moveSystem
	_unitsMgr = UnitsMgr.New()

	local a, b = _moveSystem:GetMulRet()
	print(a, b)

	_unitPrefab =
	{
		GameObject.Find("Res/Unit01"),
		GameObject.Find("Res/Unit02"),
		GameObject.Find("Res/Bullet01"),
	}

	local ringObj = GameObject.Find('Base/Ring')
	_ring = ringObj.transform

	local t1
	t1 = Tower.New()
	t1.x, t1.z = 3, 0
	table.insert(_towerMgr, t1)

	t1 = Tower.New()
	t1.x, t1.z = 13, 0
	table.insert(_towerMgr, t1)

	local ints = _moveSystem.GetInts()
	print(ints.Count)
end

local _ringQuat
local _ringAngle = 0

function module.Update()
	_deltaTime = Time.deltaTime

	for i = 1, #_towerMgr do
		Tower.Update(_towerMgr[i])
	end

	_unitsMgr:Update()

	_ringAngle = _ringAngle + 0.5 * _deltaTime
	while _ringAngle > math.pi*2 do
		_ringAngle = _ringAngle - math.pi*2
	end
	_ringQuat = Quaternion.AngleAxis(_ringAngle, 0, 0, 1, _ringQuat)
	_ring.localRotation = _ringQuat
end

return module



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
local Example05 = bLua.Example05
local Vector3 = Math.Vector3

local _moveSystem
local _deltaTime
local _unitsMgr
local _unitPrefab
local _towerMgr = {}

local _unit_pid_seed = 0

local Unit = {}
Unit.__index = Unit

function Unit.New()
	_unit_pid_seed = _unit_pid_seed + 1

	local obj =
	{
		pid = _unit_pid_seed,
		name = 'Fighter',
		hp = 100,
		speed = 3,
		x = 0,
		z = 0,
		position = { 0, 0, 0 },

		state = 1,
		ai = { },
	}
	setmetatable(obj, Unit)
	return obj
end

function Unit:OnIdle()
	local path

	path = _moveSystem:FindPath(self.x, self.z, 0, 0)
	print(#path)
	for i = 1, #path / 2 do
		print(path[i*2-1], path[i*2])
	end
	self.ai.path = path
	self.ai.time = 0
	self.ai.position = self.transform.localPosition

	self.state = 2
end

function Unit:OnMove()
end

function Unit:OnAttack()
end

Unit.actions = { Unit.OnIdle, Unit.OnMove, Unit.OnAttack }

function Unit:LoadModel()
	self.gameObject = _unitPrefab[1]:Clone()
	self.gameObject.name = string.format('unit_%d', self.pid)
	self.transform = self.gameObject.transform
	self.transform.parent = nil
	self.transform.localPosition = self.position
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
	self.unit[unit.pid] = nil
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
		position = { 0, 0, 0 },
		time = 0,
	}
	setmetatable(obj, Tower)
	return obj
end

function Tower:Update()
	local unit

	self.time = self.time + _deltaTime
	if self.time < 5 then
		goto end_of_update
	end
	self.time = 0

	unit = Unit.New()

	Vector3.Set1(unit.position, self.position)
	unit.position[3] = unit.position[3] + 1
	unit.x = unit.position[1] + 8
	unit.z = unit.position[3] + 10

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

	path = _moveSystem:FindPath(0, 0, 2, 0)
	for i = 1, #path / 2 do
		print(path[2*i-1], path[2*i])
	end

	_unitPrefab =
	{
		GameObject.Find("Res/Unit01"),
		GameObject.Find("Res/Unit02"),
		GameObject.Find("Res/Bullet01"),
	}

	local t1
	t1 = Tower.New()
	Vector3.Set(t1.position, -3, 0, -8)
	table.insert(_towerMgr, t1)

	t1 = Tower.New()
	Vector3.Set(t1.position, 3, 0, -8)
	table.insert(_towerMgr, t1)
end

function module.Update()
	_deltaTime = Time.deltaTime

	for i = 1, #_towerMgr do
		Tower.Update(_towerMgr[i])
	end

	_unitsMgr:Update()

end

return module



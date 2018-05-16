local TAG = "UIManager"
local UIManager = UIManager or {};
local UIRoot = nil

local stack = require "base.Stack"

local Stack = stack:ctor();


function UIManager.regeist(name,root,instance)
	print("regeist");
	if UIManager[name] then
		print(" contains this ui ");
		return;
	end
	UIManager[name] = {};
	UIManager[name]["root"] = root or UIManager.root()

	UIManager[name].context.instance = instance 
end
function UIManager.root()
	UIRoot = UnityEngine.GameObject.FindGameObjectWithTag("UIRoot");
	return UIRoot;
end

function UIManager.Open(name)
	if not UIManager["name"] then
		print("this is null");
		return
	end
	--把UI插入场景栈里
	print();
	Stack:push(name);

	local obj = LoadGameObject(name);

	if not UIManager[name].root then
		UIManager[name].root = UIManager.root();
	end
	obj.transform.root = UIManager[name].root;
	Log.iData(TAG,UIManager[name])
	UIManager[name].context.instance:Start();
end

function UIManager.Clear()
	-- body
end

return UIManager
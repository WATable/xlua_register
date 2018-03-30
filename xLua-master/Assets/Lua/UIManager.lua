
local UIManager = UIManager or {};

local stack = {}


function UIManager.regeist(name,obj,root)
	
	if UIManager[name] then
		print(" contains this ui ");
		return;
	end
	UIManager[name] = {};
	UIManager[name]["gameObject"] = obj
	UIManager[name]["root"] = root 


end



function UIManager.Open(name)
	if not UIManager["name"] then
		print("this is null");
		return
	end
	--把场景插入场景栈里
	table.insert( stack, name )

	
	
	local obj = UnityEngine.GameObject.Instantiate(name,);
end
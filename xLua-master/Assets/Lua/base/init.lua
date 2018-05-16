unpack = unpack or table.unpack

UnityEngine = CS.UnityEngine;

Mathf = CS.UnityEngine.Mathf;
UI = CS.UnityEngine.UI;

AI = CS.UnityEngine.AI;

AssetManager = CS.AssetManager;

UIManager = require "base.UIManager"


require "view.Login"

Stack = require "base.Stack";
Log = require "base.Log";
require "base.Header"
require "config.Header"
require "module.Header"
require "view.Header"


function LoadGameObject(fillName,parent)
	local Game = AssetManager.Load(fillName);
	local root = UIManager.root().transform;

	local obj = UnityEngine.GameObject.Instantiate(Game,parent or root);
	return obj;
end


local linknode_metatable = {
    __index = function(t, k)
        if typeof(k) and t.gameObject then
            return t.gameObject:GetComponent(typeof(k));
        end
    end
}


-- local function SetupLinkNode(root)
--     if root == nil then
--         return nil
--     end

--     local view = setmetatable({gameObject = root, name = root.name}, linknode_metatable);

--     local node = root:GetComponent(typeof(CS.SGK.UIReference))
--     if node then
--         for i = 1, node.nodes.Length do
--             local obj = node.nodes[i - 1];
--             if obj then
--                 view[obj.name] = SetupLinkNode(obj)
--             end
--         end
--     end
--     return view
-- end

-- rawset(CS.UIReference, "Setup", function(obj)
--     return SetupLinkNode(obj)
-- end);



setmetatable(_G, {__index=function(t, k)
    ERROR_LOG("GLOBAL NAME", k, "NOT EXISTS", debug.traceback())
end, __newindex = function(t, k, v)
    ERROR_LOG("SET GLOBAL NAME", k, v, debug.traceback())
    rawset(t, k, v);
end})


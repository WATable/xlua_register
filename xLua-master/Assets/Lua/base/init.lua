unpack = unpack or table.unpack

UnityEngine = CS.UnityEngine;

Mathf = CS.UnityEngine.Mathf;
UI = CS.UnityEngine.UI;

AI = CS.UnityEngine.AI;

AssetManager = CS.AssetManager;
Log = require "base.Log";
UIManager = require "base.UIManager"
require "view.Login"

Stack = require "base.Stack";

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


-- 打印表的格式的方法
local function _sprinttb(tb, tabspace)
    tabspace =tabspace or ''
    local str =string.format(tabspace .. '{\n' )
    for k,v in pairs(tb or {}) do
        if type(v)=='table' then
            if type(k)=='string' then
                str =str .. string.format("%s%s =\n", tabspace..'  ', k)
                str =str .. _sprinttb(v, tabspace..'  ')
            elseif type(k)=='number' then
                str =str .. string.format("%s[%d] =\n", tabspace..'  ', k)
                str =str .. _sprinttb(v, tabspace..'  ')
            end
        else
            if type(k)=='string' then
                str =str .. string.format("%s%s = %s,\n", tabspace..'  ', tostring(k), tostring(v))
            elseif type(k)=='number' then
                str =str .. string.format("%s[%s] = %s,\n", tabspace..'  ', tostring(k), tostring(v))
            end
        end
    end
    str =str .. string.format(tabspace .. '},\n' )
    return str
end

function sprinttb(tb, tabspace)
    local function ss()
        return _sprinttb(tb, tabspace);
    end
    return setmetatable({}, {
        __concat = ss,
        __tostring = ss,
    });
end


function Setup(root)
    if not root then return end
    local view = setmetatable({gameObject = root,name = root.name},linknode_metatable);
    local linkNode = root:GetComponent(typeof(CS.LinkNode));

    if linkNode then

        print(linkNode.nodes);

        for i=1,linkNode.nodes.Length do
            local v = linkNode.nodes[i-1];

             if v then
                view[v.name] = Setup(v);
            end
        end
        print(sprinttb(view));
    end
    return view
end


-- Log.iData("===========",UIManager);
UIManager.Init();

UIManager.ShowPanel("Login",1);


setmetatable(_G, {__index=function(t, k)
    ERROR_LOG("GLOBAL NAME", k, "NOT EXISTS", debug.traceback())
end, __newindex = function(t, k, v)
    ERROR_LOG("SET GLOBAL NAME", k, v, debug.traceback())
    rawset(t, k, v);
end})


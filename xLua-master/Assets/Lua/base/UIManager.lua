local TAG = "UIManager"
local UIManager = UIManager or {};
local UIRoot = nil
local stack = require "base.Stack"

local Stack = stack:ctor();

-- require "UISystems/Common/UIDefine"
-- require 'Common/StackList'
local this = UIManager
local ctrlList = {}
local panelStack = nil

local UIPanels = require "view/Header"
-- --[[
-- 对table运用#计算长度要求
-- ]]
-- --初始化时，将panel和ctrl require进来，并执行ctrl.Init()
function this.Init()
    --logWarn("ctrl mgr init ctrl len is : ");
    panelStack = Stack;
    for k,v in pairs(UIPanels) do
    	local ctrl = v;
        if type(ctrl) == 'boolean' then
            error(' require ctrl error, 找不到lua文件path: ');
        else
        	-- print("初始化",k);
        end
        ctrlList[k] = ctrl
        --attempt to index a boolean value
        --出现上面那个错，说明require路径没写对
        ctrlList[k].panelName = panel --这里赋值panel给UICtrl
    end
end

local UIRoot = nil
function this.root()
	if not UIRoot then
		local root = UnityEngine.GameObject.Find("Canvas");
		UIRoot = root;
	end

	Log.iData(TAG,UIRoot)

	return UIRoot;
end

function this.ShowPanel(panelName,data)
	local panel = ctrlList[panelName];

	if not panel then error("找不到panel"..panelName) end;
	local luaBehaviour = CS.LuaBehaviour;

	print("-----",sprinttb(luaBehaviour));
	panel.gameObject = LoadGameObject(panelName);
	panel.gameObject:AddComponent(luaBehaviour.GetThisType());
	panel:Start(data);
	

	stack:push(panel);
end

function this.Open(panelName,data)
	this.ShowPanel(panelName,data);
end



function this.DestroyPanel()
	local current = stack:pop();
	print(sprinttb(current));
	if current then
		if current["OnDestroy"] then
			current:OnDestroy();
		end
		UnityEngine.Object.Destroy(current.gameObject);
	end
end

-- function this.Tick()
-- 	for i=1,#Stack do
-- 		Stack[i]:Update();
-- 	end
-- end


function this.Pop()
	this.DestroyPanel()
end


return UIManager;

local TAG = "Login"
local Login ={} 
--注册进入到UI管理器里


function Login:Start(data)
	-- local obj = LoadGameObject("Login");

	local view = Setup(self.gameObject);

	view.Button[UI.Button].onClick:AddListener(function ( ... )
		-- UIManager.Open("InstantieAllBox");
		if not self.stack then
			self.stack = Stack:ctor();
			self.stack1 = Stack:ctor();
		else
			Stack:push(#self.stack1 + 1);
		end
		if self.stack1[1] == 10 then
			print("===========");
			UIManager.Open("InstantieAllBox");
		end
		print(sprinttb(self.stack),sprinttb(self.stack1));
	end)
	print(sprinttb(view));
end


function Login:Update( )
	
end

return Login
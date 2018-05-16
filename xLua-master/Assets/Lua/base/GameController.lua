local GameController = {}


function GameController:Update()
	UIManager.Tick()



	if UnityEngine.Input.GetKeyDown(UnityEngine.KeyCode.Escape) then
		print("Esc");
		UIManager.Pop();
	end
end

return GameController;
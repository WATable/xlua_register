local TAG = "InstantieAllBox"

local InstantieAllBox ={}




function InstantieAllBox:Start()

	self.root = UnityEngine.GameObject.FindWithTag("BoxRoot")
	self.data = {};

	self.maxRow =10;
	self.maxColumns = 10;



	for row=1,self.maxRow do
		self.data[row] = {}

		local root = UnityEngine.GameObject("root"..row);

		local rootItem = root.transform;
		rootItem.transform.parent = self.root.transform;

		for Columns=1,self.maxColumns do
			self.data[row][Columns] = self:CreateBox(row,Columns,rootItem);
		end
	end

	local half = (self.maxRow * self.maxColumns)/2;

	local row = half/10;
	local Columns = (half%5~=0) or 10;

	Log.iData(TAG,self.data[row][Columns]);

	self.data[row][Columns]:SetActive(false);
end


function InstantieAllBox:CreateBox(row,Columns,root)
	local obj = LoadGameObject("Box");
	obj.transform.parent = root;
	obj.name = (row-1)*10+Columns;
	local scale = obj.transform.localScale;
	obj.transform.localPosition = self:SetBoxPos(scale.x,scale.y,(row-1),(Columns-1));
	return obj;
end

function InstantieAllBox:SetBoxPos(x,y,row,Columns)
	
	local pos = UnityEngine.Vector3(((row or 0)-self.maxRow/2)*x,((Columns or 0)-self.maxColumns/2)*y,0);
	return pos;
end







return InstantieAllBox;
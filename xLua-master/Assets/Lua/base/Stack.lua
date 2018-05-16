local Stack = {};

--声明一个栈
function Stack:ctor()
	self.stack = {}
	return self.stack;
end

function Stack:push(value)
	if not value then
		return;
	end

	table.insert(self.stack,1,value);
end


function Stack:pop()
	if #self.stack >0 then
		return table.remove(self.stack,1);
	end
	return nil
end

function Stack:clear()
	self.stack =nil
	self.stack = {};
end

function Stack:length()
	return #self.stack or 0;
end


return Stack;









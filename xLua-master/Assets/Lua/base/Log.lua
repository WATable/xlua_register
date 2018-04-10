
Log = Log or {
	m_debugModule = true;
}

local logTag = "Log";
App_Log_Level = 0;

if true then
	local logFunc = print;

	local function info(Tag,...)
		if App_Log_Level == 0 then
			logFunc(Tag .. " :",...);
		end
	end

	local function debugInfo(Tag,...)
		if App_Log_Level < 2 then
			local info = debug.getinfo(3)
			logFunc(Tag .. " :", string.format("%s:%d", info.source, info.currentline), ...);
		end
	end

	local function depthString(depth)
		local ret = "";
		depth = depth or 0;
		for i = 1,depth,1 do
			ret =  ret .. "\t";
		end
		return ret;
	end

	local function tableToString(key,value,depth)
		local ret = "";
		local str = depthString(depth);
		if string.find(key, "m_") then
			return "";
		end
		if type(value) == "table" then
			ret = ret .. str .. "[" .. key .. "]\t" .. tostring(value) .. "\t" .. type(value) .. "\n";
			for k,v in pairs(value) do
				ret = ret .. tableToString(tostring(k), v, depth + 1);
			end
		else
			ret = ret .. str .. "[" .. tostring(key) .. "]\t" .. tostring(value) .. "\t"..type(value) .. "\n";
		end
		return ret;
	end

	function Log.debugModule(isOpen)
		m_debugModule = isOpen;
		
		debugInfo = function (...) end;
	end

	function Log.i(Tag,...)
		Tag = Tag or logTag;
		info(Tag,...);
	end

	function Log.d(Tag,...)
		Tag = Tag or logTag;
		debugInfo(Tag,...);
	end

	function Log.e(Tag,...)
		Tag = Tag or logTag;
		if App_Log_Level < 3 then
			ERROR_LOG(Tag, ...);
			ERROR_LOG(Tag, debug.traceback(), "\n");
		end
	end

	function Log.iData(Tag,data,desc, ...)
		Tag = Tag or logTag;
		logFunc("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++")
		local info = debug.getinfo(2)
		logFunc(Tag, string.format("%s:%d", info.source, info.currentline), desc or "dump data", ...)
		logFunc(tableToString("",data,0));
		logFunc("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++")
	end

	function Log.a(TAG,b,...)
		if not b then
			Log.e(TAG,...);
		end
	end
	--[[
	print = function ( ... )
		logFunc("\n")
		logFunc("!!!!!!!!!!! 'print' please replace of 'Log' !!!!!!!!!!!");
		Log.d(TAG, "unkown module", ...);
		logFunc("!!!!!!!!!!! ------------------------------- !!!!!!!!!!!\n");
	end
	-- ]]
else
	function Log.debugModule()
	end

	function Log.i(...)
	end

	function Log.d(...)
	end

	function Log.e(...)
	end

	function Log.iData(...)
	end

	function Log.a(...)
	end
	print = function (...)
		
	end
end

return Log;

use Ams;

-- 生产班组菜单
INSERT INTO sys_menu(menuName, parentId, SortingNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by, create_time) 
VALUES ('生产班组', 1124, 999, 'PpLine', 'logistics/PpLine', 0, 0, 'C', '0', '0', 'ppline:list', 'icon1', 'system', GETDATE());

-- 按钮父菜单id
declare @menuId int = @@identity


INSERT INTO sys_menu(menuName, parentId, SortingNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by,create_time) 
VALUES ('查询', @menuId, 1, '#', NULL, 0, 0, 'F', '0', '0', 'ppline:query', '', 'system', GETDATE());

INSERT INTO sys_menu(menuName, parentId, SortingNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by,create_time) 
VALUES ('新增', @menuId, 2, '#', NULL, 0, 0, 'F', '0', '0', 'ppline:add', '', 'system', GETDATE());

INSERT INTO sys_menu(menuName, parentId, SortingNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by,create_time) 
VALUES ('删除', @menuId, 3, '#', NULL, 0, 0, 'F', '0', '0', 'ppline:delete', '', 'system', GETDATE());

INSERT INTO sys_menu(menuName, parentId, SortingNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by,create_time) 
VALUES ('修改', @menuId, 4, '#', NULL, 0, 0, 'F', '0', '0', 'ppline:edit', '', 'system', GETDATE());

SELECT * FROM sys_menu WHERE parentId = @menuId;
SELECT * FROM sys_menu WHERE menuId = @menuId;
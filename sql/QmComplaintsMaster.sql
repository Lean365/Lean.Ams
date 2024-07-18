use Lean365;

-- 主客诉管理菜单
INSERT INTO sys_menu(menuName, parentId, SortingNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, Create_by, Create_time,menuName_key) 
VALUES ('主客诉管理', 1144, 999, 'QmComplaintsMaster', 'logistics/QmComplaintsMaster', 0, 0, 'C', '0', '0', 'qm:complaintsmaster:list', 'icon1', 'Lean365', GETDATE(), 'menu.qm.complaintsmaster');

-- 按钮父菜单id
declare @menuId int = @@identity


INSERT INTO sys_menu(menuName, parentId, SortingNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, Create_by,Create_time,menuName_key) 
VALUES ('查询', @menuId, 1, '#', NULL, 0, 0, 'F', '0', '0', 'qm:complaintsmaster:query', '', 'Lean365', GETDATE(), 'btn.search');

INSERT INTO sys_menu(menuName, parentId, SortingNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, Create_by,Create_time,menuName_key) 
VALUES ('新增', @menuId, 2, '#', NULL, 0, 0, 'F', '0', '0', 'qm:complaintsmaster:add', '', 'Lean365', GETDATE(), 'btn.add');

INSERT INTO sys_menu(menuName, parentId, SortingNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, Create_by,Create_time,menuName_key) 
VALUES ('删除', @menuId, 3, '#', NULL, 0, 0, 'F', '0', '0', 'qm:complaintsmaster:delete', '', 'Lean365', GETDATE(), 'btn.delete');

INSERT INTO sys_menu(menuName, parentId, SortingNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, Create_by,Create_time,menuName_key) 
VALUES ('修改', @menuId, 4, '#', NULL, 0, 0, 'F', '0', '0', 'qm:complaintsmaster:edit', '', 'Lean365', GETDATE(), 'btn.edit');
INSERT INTO sys_menu(menuName, parentId, SortingNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, Create_by,Create_time,menuName_key) 
VALUES ('导出', @menuId, 5, '#', NULL, 0, 0, 'F', '0', '0', 'qm:complaintsmaster:export', '', 'Lean365', GETDATE(), 'btn.export');
INSERT INTO sys_menu(menuName, parentId, SortingNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, Create_by,Create_time,menuName_key) 
VALUES ('导入', @menuId, 6, '#', NULL, 0, 0, 'F', '0', '0', 'qm:complaintsmaster:import', '', 'Lean365', GETDATE(), 'btn.import');

SELECT * FROM sys_menu WHERE parentId = @menuId;
SELECT * FROM sys_menu WHERE menuId = @menuId;


-- 主客诉管理多语言
-- SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT) AS '随机数'

INSERT INTO sys_locale_lang(id,lang_code, lang_key, lang_name, Create_by, Create_time) 
VALUES ((SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT))+1144001,'zh-cn', 'menu.qm.complaintsmaster', '主客诉管理', 'Lean365', GETDATE());

INSERT INTO sys_locale_lang(id,lang_code, lang_key, lang_name, Create_by, Create_time) 
VALUES ((SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT))+1144002,'zh-tw', 'menu.qm.complaintsmaster', 'TW_主客诉管理', 'Lean365', GETDATE());

INSERT INTO sys_locale_lang(id,lang_code, lang_key, lang_name, Create_by, Create_time) 
VALUES ((SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT))+1144003,'en', 'menu.qm.complaintsmaster', 'EN_主客诉管理', 'Lean365', GETDATE());

INSERT INTO sys_locale_lang(id,lang_code, lang_key, lang_name, Create_by, Create_time) 
VALUES ((SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT))+1144004,'ja', 'menu.qm.complaintsmaster', 'JA_主客诉管理', 'Lean365', GETDATE());
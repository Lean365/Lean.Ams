use Ams_Tes;

-- 生产班组菜单
INSERT INTO sys_menu(menuName, parentId, SortingNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, Create_by, Create_time,menuName_key) 
VALUES ('生产班组', 1139, 999, 'PpMasterWorkshop', 'logistics/PpMasterWorkshop', 0, 0, 'C', '0', '0', 'pp:masterworkshop:list', 'icon1', 'Lean365', GETDATE(), 'menu.pp.masterworkshop');

-- 按钮父菜单id
declare @menuId int = @@identity


INSERT INTO sys_menu(menuName, parentId, SortingNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, Create_by,Create_time,menuName_key) 
VALUES ('查询', @menuId, 1, '#', NULL, 0, 0, 'F', '0', '0', 'pp:masterworkshop:query', '', 'Lean365', GETDATE(), 'btn.search');

INSERT INTO sys_menu(menuName, parentId, SortingNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, Create_by,Create_time,menuName_key) 
VALUES ('新增', @menuId, 2, '#', NULL, 0, 0, 'F', '0', '0', 'pp:masterworkshop:add', '', 'Lean365', GETDATE(), 'btn.add');

INSERT INTO sys_menu(menuName, parentId, SortingNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, Create_by,Create_time,menuName_key) 
VALUES ('删除', @menuId, 3, '#', NULL, 0, 0, 'F', '0', '0', 'pp:masterworkshop:delete', '', 'Lean365', GETDATE(), 'btn.delete');

INSERT INTO sys_menu(menuName, parentId, SortingNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, Create_by,Create_time,menuName_key) 
VALUES ('修改', @menuId, 4, '#', NULL, 0, 0, 'F', '0', '0', 'pp:masterworkshop:edit', '', 'Lean365', GETDATE(), 'btn.edit');
INSERT INTO sys_menu(menuName, parentId, SortingNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, Create_by,Create_time,menuName_key) 
VALUES ('导出', @menuId, 5, '#', NULL, 0, 0, 'F', '0', '0', 'pp:masterworkshop:export', '', 'Lean365', GETDATE(), 'btn.export');
INSERT INTO sys_menu(menuName, parentId, SortingNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, Create_by,Create_time,menuName_key) 
VALUES ('导入', @menuId, 6, '#', NULL, 0, 0, 'F', '0', '0', 'pp:masterworkshop:import', '', 'Lean365', GETDATE(), 'btn.import');

SELECT * FROM sys_menu WHERE parentId = @menuId;
SELECT * FROM sys_menu WHERE menuId = @menuId;


-- 生产班组多语言
-- SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT) AS '随机数'

INSERT INTO sys_locale_lang(id,lang_code, lang_key, lang_name, Create_by, Create_time) 
VALUES ((SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT))+1139001,'zh-cn', 'menu.pp.masterworkshop', '生产班组', 'Lean365', GETDATE());

INSERT INTO sys_locale_lang(id,lang_code, lang_key, lang_name, Create_by, Create_time) 
VALUES ((SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT))+1139002,'zh-tw', 'menu.pp.masterworkshop', 'TW_生产班组', 'Lean365', GETDATE());

INSERT INTO sys_locale_lang(id,lang_code, lang_key, lang_name, Create_by, Create_time) 
VALUES ((SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT))+1139003,'en', 'menu.pp.masterworkshop', 'EN_生产班组', 'Lean365', GETDATE());

INSERT INTO sys_locale_lang(id,lang_code, lang_key, lang_name, Create_by, Create_time) 
VALUES ((SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT))+1139004,'ja', 'menu.pp.masterworkshop', 'JA_生产班组', 'Lean365', GETDATE());

INSERT INTO sys_locale_lang(id,lang_code, lang_key, lang_name, Create_by, Create_time) 
VALUES ((SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT))+1139003,'fr', 'menu.pp.masterworkshop', 'FR_生产班组', 'Lean365', GETDATE());

INSERT INTO sys_locale_lang(id,lang_code, lang_key, lang_name, Create_by, Create_time) 
VALUES ((SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT))+1139003,'ko', 'menu.pp.masterworkshop', 'KO_生产班组', 'Lean365', GETDATE());

INSERT INTO sys_locale_lang(id,lang_code, lang_key, lang_name, Create_by, Create_time) 
VALUES ((SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT))+1139003,'ar', 'menu.pp.masterworkshop', 'AR_生产班组', 'Lean365', GETDATE());

INSERT INTO sys_locale_lang(id,lang_code, lang_key, lang_name, Create_by, Create_time) 
VALUES ((SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT))+1139003,'ru', 'menu.pp.masterworkshop', 'RU_生产班组', 'Lean365', GETDATE());

INSERT INTO sys_locale_lang(id,lang_code, lang_key, lang_name, Create_by, Create_time) 
VALUES ((SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT))+1139003,'de', 'menu.pp.masterworkshop', 'DE_生产班组', 'Lean365', GETDATE());

INSERT INTO sys_locale_lang(id,lang_code, lang_key, lang_name, Create_by, Create_time) 
VALUES ((SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT))+1139003,'es', 'menu.pp.masterworkshop', 'ES_生产班组', 'Lean365', GETDATE());

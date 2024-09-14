use Ams_Tes;

-- 分析对策菜单
INSERT INTO sys_menu(menuName, parentId, SortingNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, Create_by, Create_time,menuName_key) 
VALUES ('分析对策', 1142, 999, 'QmIpvReply', 'logistics/QmIpvReply', 0, 0, 'C', '0', '0', 'qm:ipvreply:list', 'icon1', 'Lean365', GETDATE(), 'menu.qm.ipvreply');

-- 按钮父菜单id
declare @menuId int = @@identity


INSERT INTO sys_menu(menuName, parentId, SortingNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, Create_by,Create_time,menuName_key) 
VALUES ('查询', @menuId, 1, '#', NULL, 0, 0, 'F', '0', '0', 'qm:ipvreply:query', '', 'Lean365', GETDATE(), 'btn.search');

INSERT INTO sys_menu(menuName, parentId, SortingNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, Create_by,Create_time,menuName_key) 
VALUES ('新增', @menuId, 2, '#', NULL, 0, 0, 'F', '0', '0', 'qm:ipvreply:add', '', 'Lean365', GETDATE(), 'btn.add');

INSERT INTO sys_menu(menuName, parentId, SortingNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, Create_by,Create_time,menuName_key) 
VALUES ('删除', @menuId, 3, '#', NULL, 0, 0, 'F', '0', '0', 'qm:ipvreply:delete', '', 'Lean365', GETDATE(), 'btn.delete');

INSERT INTO sys_menu(menuName, parentId, SortingNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, Create_by,Create_time,menuName_key) 
VALUES ('修改', @menuId, 4, '#', NULL, 0, 0, 'F', '0', '0', 'qm:ipvreply:edit', '', 'Lean365', GETDATE(), 'btn.edit');
INSERT INTO sys_menu(menuName, parentId, SortingNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, Create_by,Create_time,menuName_key) 
VALUES ('导出', @menuId, 5, '#', NULL, 0, 0, 'F', '0', '0', 'qm:ipvreply:export', '', 'Lean365', GETDATE(), 'btn.export');
INSERT INTO sys_menu(menuName, parentId, SortingNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, Create_by,Create_time,menuName_key) 
VALUES ('导入', @menuId, 6, '#', NULL, 0, 0, 'F', '0', '0', 'qm:ipvreply:import', '', 'Lean365', GETDATE(), 'btn.import');

SELECT * FROM sys_menu WHERE parentId = @menuId;
SELECT * FROM sys_menu WHERE menuId = @menuId;


-- 分析对策多语言
-- SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT) AS '随机数'

INSERT INTO sys_locale_lang(id,lang_code, lang_key, lang_name, Create_by, Create_time) 
VALUES ((SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT))+1142001,'zh-cn', 'menu.qm.ipvreply', '分析对策', 'Lean365', GETDATE());

INSERT INTO sys_locale_lang(id,lang_code, lang_key, lang_name, Create_by, Create_time) 
VALUES ((SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT))+1142002,'zh-tw', 'menu.qm.ipvreply', 'TW_分析对策', 'Lean365', GETDATE());

INSERT INTO sys_locale_lang(id,lang_code, lang_key, lang_name, Create_by, Create_time) 
VALUES ((SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT))+1142003,'en', 'menu.qm.ipvreply', 'EN_分析对策', 'Lean365', GETDATE());

INSERT INTO sys_locale_lang(id,lang_code, lang_key, lang_name, Create_by, Create_time) 
VALUES ((SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT))+1142004,'ja', 'menu.qm.ipvreply', 'JA_分析对策', 'Lean365', GETDATE());

INSERT INTO sys_locale_lang(id,lang_code, lang_key, lang_name, Create_by, Create_time) 
VALUES ((SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT))+1142003,'fr', 'menu.qm.ipvreply', 'FR_分析对策', 'Lean365', GETDATE());

INSERT INTO sys_locale_lang(id,lang_code, lang_key, lang_name, Create_by, Create_time) 
VALUES ((SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT))+1142003,'ko', 'menu.qm.ipvreply', 'KO_分析对策', 'Lean365', GETDATE());

INSERT INTO sys_locale_lang(id,lang_code, lang_key, lang_name, Create_by, Create_time) 
VALUES ((SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT))+1142003,'ar', 'menu.qm.ipvreply', 'AR_分析对策', 'Lean365', GETDATE());

INSERT INTO sys_locale_lang(id,lang_code, lang_key, lang_name, Create_by, Create_time) 
VALUES ((SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT))+1142003,'ru', 'menu.qm.ipvreply', 'RU_分析对策', 'Lean365', GETDATE());

INSERT INTO sys_locale_lang(id,lang_code, lang_key, lang_name, Create_by, Create_time) 
VALUES ((SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT))+1142003,'de', 'menu.qm.ipvreply', 'DE_分析对策', 'Lean365', GETDATE());

INSERT INTO sys_locale_lang(id,lang_code, lang_key, lang_name, Create_by, Create_time) 
VALUES ((SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT))+1142003,'es', 'menu.qm.ipvreply', 'ES_分析对策', 'Lean365', GETDATE());

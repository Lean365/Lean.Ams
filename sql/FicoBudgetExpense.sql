use Ams_Tes;

-- 费用预算菜单
INSERT INTO sys_menu(menuName, parentId, SortingNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, Create_by, Create_time,menuName_key) 
VALUES ('费用预算', 1567, 999, 'FicoBudgetExpense', 'accounting/FicoBudgetExpense', 0, 0, 'C', '0', '0', 'fico:budgetexpense:list', 'icon1', 'Lean365', GETDATE(), 'menu.fico.budgetexpense');

-- 按钮父菜单id
declare @menuId int = @@identity


INSERT INTO sys_menu(menuName, parentId, SortingNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, Create_by,Create_time,menuName_key) 
VALUES ('查询', @menuId, 1, '#', NULL, 0, 0, 'F', '0', '0', 'fico:budgetexpense:query', '', 'Lean365', GETDATE(), 'btn.search');

INSERT INTO sys_menu(menuName, parentId, SortingNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, Create_by,Create_time,menuName_key) 
VALUES ('新增', @menuId, 2, '#', NULL, 0, 0, 'F', '0', '0', 'fico:budgetexpense:add', '', 'Lean365', GETDATE(), 'btn.add');

INSERT INTO sys_menu(menuName, parentId, SortingNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, Create_by,Create_time,menuName_key) 
VALUES ('删除', @menuId, 3, '#', NULL, 0, 0, 'F', '0', '0', 'fico:budgetexpense:delete', '', 'Lean365', GETDATE(), 'btn.delete');

INSERT INTO sys_menu(menuName, parentId, SortingNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, Create_by,Create_time,menuName_key) 
VALUES ('修改', @menuId, 4, '#', NULL, 0, 0, 'F', '0', '0', 'fico:budgetexpense:edit', '', 'Lean365', GETDATE(), 'btn.edit');
INSERT INTO sys_menu(menuName, parentId, SortingNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, Create_by,Create_time,menuName_key) 
VALUES ('导出', @menuId, 5, '#', NULL, 0, 0, 'F', '0', '0', 'fico:budgetexpense:export', '', 'Lean365', GETDATE(), 'btn.export');
INSERT INTO sys_menu(menuName, parentId, SortingNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, Create_by,Create_time,menuName_key) 
VALUES ('导入', @menuId, 6, '#', NULL, 0, 0, 'F', '0', '0', 'fico:budgetexpense:import', '', 'Lean365', GETDATE(), 'btn.import');

SELECT * FROM sys_menu WHERE parentId = @menuId;
SELECT * FROM sys_menu WHERE menuId = @menuId;


-- 费用预算多语言
-- SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT) AS '随机数'

INSERT INTO sys_locale_lang(id,lang_code, lang_key, lang_name, Create_by, Create_time) 
VALUES ((SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT))+1567001,'zh-cn', 'menu.fico.budgetexpense', '费用预算', 'Lean365', GETDATE());

INSERT INTO sys_locale_lang(id,lang_code, lang_key, lang_name, Create_by, Create_time) 
VALUES ((SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT))+1567002,'zh-tw', 'menu.fico.budgetexpense', 'TW_费用预算', 'Lean365', GETDATE());

INSERT INTO sys_locale_lang(id,lang_code, lang_key, lang_name, Create_by, Create_time) 
VALUES ((SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT))+1567003,'en', 'menu.fico.budgetexpense', 'EN_费用预算', 'Lean365', GETDATE());

INSERT INTO sys_locale_lang(id,lang_code, lang_key, lang_name, Create_by, Create_time) 
VALUES ((SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT))+1567004,'ja', 'menu.fico.budgetexpense', 'JA_费用预算', 'Lean365', GETDATE());

INSERT INTO sys_locale_lang(id,lang_code, lang_key, lang_name, Create_by, Create_time) 
VALUES ((SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT))+1567003,'fr', 'menu.fico.budgetexpense', 'FR_费用预算', 'Lean365', GETDATE());

INSERT INTO sys_locale_lang(id,lang_code, lang_key, lang_name, Create_by, Create_time) 
VALUES ((SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT))+1567003,'ko', 'menu.fico.budgetexpense', 'KO_费用预算', 'Lean365', GETDATE());

INSERT INTO sys_locale_lang(id,lang_code, lang_key, lang_name, Create_by, Create_time) 
VALUES ((SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT))+1567003,'ar', 'menu.fico.budgetexpense', 'AR_费用预算', 'Lean365', GETDATE());

INSERT INTO sys_locale_lang(id,lang_code, lang_key, lang_name, Create_by, Create_time) 
VALUES ((SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT))+1567003,'ru', 'menu.fico.budgetexpense', 'RU_费用预算', 'Lean365', GETDATE());

INSERT INTO sys_locale_lang(id,lang_code, lang_key, lang_name, Create_by, Create_time) 
VALUES ((SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT))+1567003,'de', 'menu.fico.budgetexpense', 'DE_费用预算', 'Lean365', GETDATE());

INSERT INTO sys_locale_lang(id,lang_code, lang_key, lang_name, Create_by, Create_time) 
VALUES ((SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT))+1567003,'es', 'menu.fico.budgetexpense', 'ES_费用预算', 'Lean365', GETDATE());

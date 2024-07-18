use Lean365;

-- 加班预算菜单
INSERT INTO sys_menu(menuName, parentId, SortingNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, Create_by, Create_time,menuName_key) 
VALUES ('加班预算', 1137, 999, 'FicoBudgetOvertime', 'accounting/FicoBudgetOvertime', 0, 0, 'C', '0', '0', 'fico:budgetovertime:list', 'icon1', 'Lean365', GETDATE(), 'menu.fico.budgetovertime');

-- 按钮父菜单id
declare @menuId int = @@identity


INSERT INTO sys_menu(menuName, parentId, SortingNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, Create_by,Create_time,menuName_key) 
VALUES ('查询', @menuId, 1, '#', NULL, 0, 0, 'F', '0', '0', 'fico:budgetovertime:query', '', 'Lean365', GETDATE(), 'btn.search');

INSERT INTO sys_menu(menuName, parentId, SortingNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, Create_by,Create_time,menuName_key) 
VALUES ('新增', @menuId, 2, '#', NULL, 0, 0, 'F', '0', '0', 'fico:budgetovertime:add', '', 'Lean365', GETDATE(), 'btn.add');

INSERT INTO sys_menu(menuName, parentId, SortingNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, Create_by,Create_time,menuName_key) 
VALUES ('删除', @menuId, 3, '#', NULL, 0, 0, 'F', '0', '0', 'fico:budgetovertime:delete', '', 'Lean365', GETDATE(), 'btn.delete');

INSERT INTO sys_menu(menuName, parentId, SortingNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, Create_by,Create_time,menuName_key) 
VALUES ('修改', @menuId, 4, '#', NULL, 0, 0, 'F', '0', '0', 'fico:budgetovertime:edit', '', 'Lean365', GETDATE(), 'btn.edit');
INSERT INTO sys_menu(menuName, parentId, SortingNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, Create_by,Create_time,menuName_key) 
VALUES ('导出', @menuId, 5, '#', NULL, 0, 0, 'F', '0', '0', 'fico:budgetovertime:export', '', 'Lean365', GETDATE(), 'btn.export');
INSERT INTO sys_menu(menuName, parentId, SortingNum, path, component, isFrame, isCache, menuType, visible, IsStatus, perms, icon, Create_by,Create_time,menuName_key) 
VALUES ('导入', @menuId, 6, '#', NULL, 0, 0, 'F', '0', '0', 'fico:budgetovertime:import', '', 'Lean365', GETDATE(), 'btn.import');

SELECT * FROM sys_menu WHERE parentId = @menuId;
SELECT * FROM sys_menu WHERE menuId = @menuId;


-- 加班预算多语言
-- SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT) AS '随机数'

INSERT INTO sys_locale_lang(id,lang_code, lang_key, lang_name, Create_by, Create_time) 
VALUES ((SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT))+1137001,'zh-cn', 'menu.fico.budgetovertime', '加班预算', 'Lean365', GETDATE());

INSERT INTO sys_locale_lang(id,lang_code, lang_key, lang_name, Create_by, Create_time) 
VALUES ((SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT))+1137002,'zh-tw', 'menu.fico.budgetovertime', 'TW_加班预算', 'Lean365', GETDATE());

INSERT INTO sys_locale_lang(id,lang_code, lang_key, lang_name, Create_by, Create_time) 
VALUES ((SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT))+1137003,'en', 'menu.fico.budgetovertime', 'EN_加班预算', 'Lean365', GETDATE());

INSERT INTO sys_locale_lang(id,lang_code, lang_key, lang_name, Create_by, Create_time) 
VALUES ((SELECT CAST(CAST(NEWID() AS VARBINARY(3)) AS INT))+1137004,'ja', 'menu.fico.budgetovertime', 'JA_加班预算', 'Lean365', GETDATE());
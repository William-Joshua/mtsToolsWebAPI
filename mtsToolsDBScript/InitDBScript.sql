USE mtsToolsDBCenter;
INSERT INTO MtsSoftwareInfo
(SoftwareID, 
 SoftwareName, 
 SoftwareAlias, 
 SoftwareVersionGUID, 
 SoftwareVersion, 
 SoftWareAddress, 
 SoftWareDescription
)
VALUES
(NEWID(), 
 'MtsToolsConsole', 
 'PCS', 
 CONVERT(VARCHAR(64), HASHBYTES('SHA1', 'MtsToolsConsole_V0.0.1'), 2), 
 'V0.0.1', 
 '\\192.168.2.253\share\软件\公司软件\MTS', 
 'MTS Tools --- 企业流水线生产作业过程控制系统'
);
INSERT INTO MtsAccountInfo
(InnerUserID, 
 UserID, 
 UserName, 
 Birthday, 
 Telephone, 
 Email, 
 EntryTime, 
 IsService, 
 PassWord, 
 Fingerprint
)
VALUES
(NEWID(), 
 'ITECH_MTS_ADMIN', 
 'ITECH MTS Administrator', 
 '', 
 '', 
 'k3@itechate.com.cn', 
 '', 
 '1SV', 
 CONVERT(VARCHAR(256), HASHBYTES('SHA1', 'ITECH_MTS_000'), 2), 
 ''
);
INSERT INTO MtsPermissionGroup
(GroupID, 
 GroupName, 
 GroupAlias, 
 IsVaild
)
VALUES
(NEWID(), 
 'Administrator', 
 'ADM', 
 '1EN'
);

INSERT INTO [dbo].[MtsMenuInfo]
([MenuName], 
 [MenuTitle], 
 [MenuParentID], 
 [MenuGroup], 
 [MenuComponent], 
 [MenuIcon], 
 [SoftwareAlias], 
 [MenuWeight], 
 [MenuCreateDate], 
 [IsMenuVaild], 
 [InnerMenuID]
)
VALUES
('Product Process', 
 '生产流程', 
 NULL, 
 'Process', 
 '', 
 'process', 
 'PCS', 
 '0', 
 GETDATE(), 
 '1EN', 
 NEWID()
);
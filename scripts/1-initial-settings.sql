IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'debezium-test')
BEGIN
CREATE DATABASE [debezium-test]
END

GO

USE [debezium-test]
GO

--You need to check if the table exists
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='outbox-table' and xtype='U')
BEGIN
    CREATE TABLE [outbox-table] (
        Id uniqueidentifier PRIMARY KEY,
        Payload NVARCHAR(MAX),
        [Type] NVARCHAR(255)
    )

    EXEC sys.sp_cdc_enable_db  

    EXEC sys.sp_cdc_enable_table  
    @source_schema = N'dbo',  
    @source_name   = N'outbox-table',  
    @role_name     = null,
    @supports_net_changes = 1  

END

GO
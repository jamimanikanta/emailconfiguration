-- update the xAFT Central Database Schema name --
use snl_testing;

-- update the Client Machine IP (hostName, hostIp) --
SET @exeTime=CURRENT_TIMESTAMP();
SET @clientIp='10.71.150.24';

-- update idTestBatch, idTestSet, idProject, executionStatus, executionOrder details and insert rows into testexecutions table to execute the below test batches --
INSERT INTO `snl_testing`.`testexecutions` (`BatchId`, `ResourceId`, `ResourceName`, `Browser`, `status`) VALUES ('2', '488', 'EPINHYDW0456', 'Mozilla FireFox', 'scheduled');

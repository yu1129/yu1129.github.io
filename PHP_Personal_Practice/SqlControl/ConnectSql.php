<?php
    $db_host = '127.0.0.1';
    $db_user = 'practice01';
    $db_password = 'Sy10161207';
    $db_database = 'practice01';

    $conn = new mysqli($db_host, $db_user, $db_password, $db_database);
    if($conn->connect_error)
        die("Connection failed :".$conn -> connect_error);
?>
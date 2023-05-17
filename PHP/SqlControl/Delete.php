<?php
    require_once "./ConnectSql.php";

    $id = $_GET['id'];

    $sql = "DELETE FROM user WHERE ID = $id";

    $result = $conn->query($sql);

    if($result){
        echo "<script>alert('Success!');window.location=\"./Read.php\";</script>";
    }
?>
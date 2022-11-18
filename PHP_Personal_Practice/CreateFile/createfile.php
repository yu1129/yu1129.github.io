<?php
    $filename = "Hello.csv";
    $filename_path = "../uploadfile/$filename";
    $fp = fopen($filename_path, "w");
    echo $fp;
    fclose($fp);
?>
<?php
    require_once "./ConnectSql.php";

    $sql = "SELECT * FROM user";
    $result = $conn->query($sql);
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>會員詳細資料</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous">
</head>
<body>
    <h2 class="text-center">會員詳細資料</h2>
    <table class="w-75 border-2 border-dark m-auto my-5">
        <tbody>
            <tr>
                <td>ID</td>
                <td>姓名</td>
                <td>生日</td>
                <td>Email</td>
                <td></td>
            </tr>
            <?php
                while($row_result = $result->fetch_assoc()){
                    echo "<tr><td class=\"userid\">{$row_result['ID']}</td><td>{$row_result['Name']}</td><td>{$row_result['Brithday']}</td><td>{$row_result['Email']}</td><td><button type=\"button\" class=\"btn btn-primary me-3\" id=\"editButton\" name=\"editButton\" value=\"eB\">編輯</button><button type=\"button\" class=\"btn btn-danger\" id=\"deleteButton\" name=\"deleteButton\" value=\"dB\">刪除</button></td></tr>";
                }
            ?>
        </tbody>
    </table>
    <div class="create w-100 d-flex justify-content-around">
        <button type="button" class="btn btn-info" id="addButton" name="addButton" value="addB">新增</button>
    </div>
    <script>
        window.onload = function(event){
            let id = document.querySelectorAll('.userid');
            let addButton = document.querySelector('#addButton');
            let editButton = document.querySelectorAll("#editButton");
            let deleteButton = document.querySelectorAll('#deleteButton');
            addButton.addEventListener("click", ()=>{
                window.location = `./Create.php`;
            });
            editButton.forEach((item, index) => item.addEventListener("click", ()=>{
                window.location = `./Update.php?id=${id[index].innerText}`;
            }));
            deleteButton.forEach((item, index) => item.addEventListener("click", ()=>{
                window.location = `./Delete.php?id=${id[index].innerText}`;
            }));
        }
    </script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p" crossorigin="anonymous"></script>
</body>
</html>
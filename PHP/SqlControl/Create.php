<?php
    require_once "./ConnectSql.php";
    $name = $_POST['Name'];
    $brithday = $_POST['Brithday'];
    $email = $_POST['Email'];
    $result;

    $sql = "INSERT INTO user(Name, Brithday, Email) VALUES ('$name', '$brithday', '$email')";
    if(isset($name)){
        $result = $conn->query($sql);
    }
    if($result){
        echo "<script>window.location = \"./Read.php\"</script>";
    }
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>會員創建</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous">
</head>
<body>
    <div class="outer w-75 m-auto mt-4">
      <form action="./Create.php" method="post">
          <div class="mb-3">
              <label for="exampleInputName1" class="form-label">姓名</label>
              <input type="test" class="form-control" id="exampleInputName1" name="Name">
          </div>
          <div class="mb-3">
            <label for="exampleInputBrithday1" class="form-label">生日</label>
            <input type="date" class="form-control" id="exampleInputBrithday1" name="Brithday">
          </div>
          <div class="mb-3">
              <label for="exampleInputEmail1" class="form-label">Email</label>
              <input type="email" class="form-control" id="exampleInputEmail1" name="Email">
          </div>
          <button type="submit" class="btn btn-primary" name="Singup" value="Create">註冊</button>
      </form>
    </div>
    
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p" crossorigin="anonymous"></script>
</body>
</html>
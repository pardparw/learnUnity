<?php
$servername = "localhost";
$username = "root";
$password = "password";
$dbname = "gps";

$lat = $_POST["Lat"];
$long = $_POST["Long"];
// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}

$sql = "SELECT p_pass,p_name FROM data WHERE lat='".$lat."' OR `long`='".$long."' ";

$result = $conn->query($sql);

if ($result->num_rows > 0) {
  // output data of each row
  while($row = $result->fetch_assoc()) {
    echo $row["p_pass"], ",", $row["p_name"];
  }
} else {
  echo "0 results";
}

$conn->close();
?>

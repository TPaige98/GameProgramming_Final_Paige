<?php
$hostname = 'localhost';
$username = 'root';
$password = '';
$database = 'paiget';

$con = mysqli_connect($hostname, $username, $password);

mysqli_select_db($con, $database) or die("Unable to connect to database");

$name = $_GET['name'];
echo 'name: ';

$score = $_GET['score'];

$query = "SELECT * FROM scores WHERE name = '$name'";
$result = mysqli_query($con, $query);
$n = mysqli_num_rows($result);

if ($n > 0)
{
	echo "Found 1 record";
	$query = "UPDATE scores SET score = '$score' WHERE name = '$name'";
}
else
{
	echo "Sorry not registered";
	$query = "INSERT INTO scores VALUES ('$name','$score')";
}
$result = mysqli_query($con, $query);
?>
<?php
$hostname = 'localhost';
$username = 'root';
$password = '';
$database = 'paiget';

$con = mysqli_connect($hostname, $username, $password);

mysqli_select_db($con, $database) or die('Unable to connect to database');

$query = 'SELECT * FROM scores ORDER BY score DESC LIMIT 10';
$result = mysqli_query($con, $query);
$n = mysqli_num_rows($result);
while ($row = mysqli_fetch_assoc($result))
{
	$name = $row["name"];
	$score = $row["score"];
	echo $name."\t";
	echo $score."\n";
}
?>
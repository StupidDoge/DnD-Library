<?php

$connection = mysqli_connect('localhost', 'root', '', 'd&d_characters'); 
$id = $_POST["id"];
$deleteCharacter = "DELETE FROM `character` WHERE id = '$id'";
$deleteAboutCharacter = "DELETE FROM `about_character` WHERE id = '$id'";
$deleteCharacteristics = "DELETE FROM `characteristics` WHERE id = '$id'";

mysqli_query($connection, $deleteAboutCharacter);
mysqli_query($connection, $deleteCharacteristics);
mysqli_query($connection, $deleteCharacter);
echo "0"
?>
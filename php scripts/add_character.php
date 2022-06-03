<?php

$connection = mysqli_connect('localhost', 'root', '', 'd&d_characters');

if ($connection->connect_error)
	exit ('1');

$characterName = $_POST["name"];
$classLevel = $_POST["class_level"];
$race = $_POST["race"];
$background = $_POST["backstory"];
$alignment = $_POST["outlook"];
$playerName = $_POST["player_name"];

$traits = $_POST["traits"];
$ideals = $_POST["ideals"];
$bounds = $_POST["affections"];
$flaws = $_POST["weaknesses"];
$attacks = $_POST["attacks"];
$equipment = $_POST["equipment"];
$allies = $_POST["allies"];
$languages = $_POST["languages"];

$strength = intval($_POST["strength"]);
$dexterity = intval($_POST["dexterity"]);
$constitution = intval($_POST["constitution"]);
$intelligence = intval($_POST["intelligence"]);
$wisdom = intval($_POST["wisdom"]);
$charisma = intval($_POST["charisma"]);
$inspiration = intval($_POST["inspiration"]);
$proficiencyBonus = intval($_POST["proficiency_bonus"]);
$armorClass = intval($_POST["armor_class"]);
$initiative = intval($_POST["initiative"]);
$speed = intval($_POST["speed"]);
$hitPoints = intval($_POST["hit_points"]);

$insertCharacter = "INSERT INTO `character` (name, class_level, race, background, alignment, player_name) VALUES ('$characterName', '$classLevel', '$race', '$background', '$alignment', '$playerName')";
$insertAboutCharacter = "INSERT INTO `about_character` (personality_traits, ideals, bounds, flaws, attacks_spellcasting, equipment, allies, other_proficiencies_languages) VALUES ('$traits', '$ideals', '$bounds', '$flaws', '$attacks', '$equipment', '$allies', '$languages')";
$insertCharacteristics = "INSERT INTO `characteristics` (strength, dexterity, constitution, intelligence, wisdom, charisma, inspiration, proficiency_bonus, armor_class, initiative, speed, current_hit_points) VALUES ('$strength', '$dexterity', '$constitution', '$intelligence', '$wisdom', '$charisma', '$inspiration', '$proficiencyBonus', '$armorClass', '$initiative', '$speed', '$hitPoints')";
mysqli_query($connection, $insertCharacter) or die("2: insert character failed");
mysqli_query($connection, $insertAboutCharacter) or die("3: insert about character failed");
mysqli_query($connection, $insertCharacteristics) or die("4: insert characteristics failed");

echo "0";

?>
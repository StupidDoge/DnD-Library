<?php

$connection = mysqli_connect('localhost', 'root', '', 'd&d_races'); 

$tableName = $_GET["tableName"];

switch ($tableName) {
	case "race":
		$content = "SELECT * FROM `race` ORDER BY race_name";
		$result = mysqli_query($connection, $content);

		if ($result)
			while ($row = mysqli_fetch_assoc($result))
				echo $row["race_name"] . ";";
		else
			echo ("Error! Cannot show race");
		break;

	case "subrace":
		$content = "SELECT * FROM `subrace` ORDER BY subrace_name";
		$result = mysqli_query($connection, $content);

		if ($result)
			while ($row = mysqli_fetch_assoc($result))
				echo $row["subrace_name"] . ";";
		else
			echo ("Error! Cannot show subrace");
		break;

	case "lineage":
		$content = "SELECT * FROM `lineage` ORDER BY lineage_name";
		$result = mysqli_query($connection, $content);

		if ($result)
			while ($row = mysqli_fetch_assoc($result))
				echo $row["lineage_name"] . ";";
		else
			echo ("Error! Cannot show lineage");
		break;

	case "dragons_types":
		$content = "SELECT * FROM `dragons_types` ORDER BY dragon";
		$result = mysqli_query($connection, $content);

		if ($result)
			while ($row = mysqli_fetch_assoc($result))
				echo $row["dragon"] . ";";
		else
			echo ("Error! Cannot show lineage");
		break;
}
?>
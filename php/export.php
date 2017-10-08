<?php

include 'key.php';

if (!ConfirmKey($_REQUEST["name"], $_REQUEST["key"])) {
	echo 'Invalid Key';
}
else {
	if ($_FILES["file"]["error"] > 0) {
		echo "Error: " . $_FILES["file"]["error"];
	}
	else {
		if (move_uploaded_file($_FILES["file"]["tmp_name"], "backup/" . $_REQUEST["key"])) {
			echo 'OK';
		}
		else {
			echo 'Could not load file. Please contact Wabilogic for assistance.';
		}
	}
}
?>

# Server Setup

Server uses NGINX autoindexing and a [modified ShareX uploader (included below)](#uploadphp) to send and receive images.

Make sure to change the secret key.

Example NGINX config:

```
server {
    listen 443 ssl;
    server_name example.com;

    root /var/www/example.com;
    index index.html index.htm index.php;
    location / {
        try_files $uri $uri/ =404;
    }

    location /fortnitegear {
        location ~ \.php$ {
            include snippets/fastcgi-php.conf;
            fastcgi_pass unix:/run/php/php7.4-fpm.sock;
        }

        location ~ /images {
            autoindex on;
            autoindex_format json;
        }
    }
}
```

Folder structure:

```
var
└─ www
   └─ example.com
      ├─ ...
      └─ fortnitegear
         ├─ upload.php
         └─ images
            └─ ...
```

Example cronjob to purge images older than 1 day every day at midnight:

```
0 0 * * * find /var/www/example.com/fortnitegear/images -type f -mtime +1 -exec rm -f {} \;
```

## upload.php
```php
<?php
header('Content-type:application/json;charset=utf-8');
error_reporting(E_ERROR);
$tokens = array("SET_YOUR_SECRET_KEYS_HERE");
$sharexdir = "images/"; //File directory

//Check for token
if(!isset($_POST['secret'])) {
    $json = ['status' => 'ERROR','errormsg' => 'No POST data received'];
    http_response_code(406);
    echo(json_encode($json));
    return;
    }

if(!in_array($_POST['secret'], $tokens)) {
    //Invalid key
    $json = ['status' => 'ERROR','errormsg' => 'Invalid secret key'];
    http_response_code(403);
    echo(json_encode($json));
    return;
    }

if(!isset($_POST['filename'])) {
    $json = ['status' => 'ERROR','errormsg' => 'No filename provided'];
    http_response_code(406);
    echo(json_encode($json));
    return;
    }

if(!isset($_FILES["gear"])) {
    $json = ['status' => 'ERROR','errormsg' => '"gear" file missing from POST.'];
    http_response_code(406);
    echo(json_encode($json));
    return;
    }

//Prepares for upload
$filename    = $_POST['filename'];
$target_file = $_FILES["gear"]["name"];
$fileType    = pathinfo($target_file, PATHINFO_EXTENSION);
$tmpName     = $_FILES["gear"]["tmp_name"];
$destination = $sharexdir . basename($filename) . '.' . $fileType;

//Accepts and moves to directory
if (move_uploaded_file($tmpName, $destination)) {
    $json = ['status' => 'OK','errormsg' => '','url' => $filename . '.' . $fileType];
    }
else {
    $json = ['status' => 'ERROR','errormsg' => '','url' => 'File upload failed. Does the folder exist and did you CHMOD the folder?'];
    http_response_code(406);
    }

echo(json_encode($json));
?>
```
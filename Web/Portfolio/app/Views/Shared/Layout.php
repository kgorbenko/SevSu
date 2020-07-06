<!DOCTYPE html>

<html lang="en">
    <head>
        <title><?=$title?></title>
    </head>
    <body>
        <nav>
            <ul>
                <li><span>Web lab1</span></li>
                <li><a href="/Home/Index">Home</a></li>
                <li><a href="/Home/About">About</a></li>
                <li><a href="/Home/Interests">My interests</a></li>
                <li><a href="/Home/Learning">Learning</a></li>
                <li><a href="/Home/Photos">Photos</a></li>
                <li><a href="/Home/Contact">Contact</a></li>
                <li><a href="/Home/Test">Test</a></li>
                <li><a href="/Home/History">History</a></li>
                <li><span id="time"></span><br/><span id="date"></span></li>
            </ul>
        </nav>
        <h1>Layout is here!</h1>
        <?php include($viewName); ?>
    </body>
</html>
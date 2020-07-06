<link href="../client-side/bundles/about.bundle.css" rel="stylesheet" type="text/css" />

<header>
    <h1>Autobiography</h1>
</header>
<section>
    <header>
        <h1>Section 1</h1>
    </header>
    <p>There should be some authobiography</p>
    <ol>
        <li>19 years old</li>
        <li>My parents's son.</li>
        <li>Dunno</li>
    </ol>
    <p>Photos:</p>
    <div class="photo-wrapper full-width">
        <?php
            foreach ($viewModel->photos as $photoName => $path) {
                echo("<img src='$path' alt='$photoName' />");
            }
        ?>
    </div>
</section>

<script src="../client-side/bundles/about.bundle.js"></script>

<link href="../client-side/bundles/contact/index.bundle.css" rel="stylesheet" type="text/css" />

<section>
    <header>
        <h1>Mail Me!</h1>
    </header>
    <p>All fields are required! Hover over fields to see the additional requirements.</p>

    <?php ViewHelper::writeValidationErrorsList($viewModel->errors); ?>

    <form action="Contact" method="POST">
        <ol>
            <li>
                <label for="full-name-input">Full Name</label>
                <input class="field-long" id="full-name-input" name="Name" type="text" />
                <br/>
            </li>
            <li>
                <label for="email-input">Email</label>
                <input class="field-long" id="email-input" name="Email" type="email" />
                <br/>
            </li>
            <li>
                <label for="phone-input">Phone number</label>
                <input class="field-long" id="phone-input" name="Phone" type="text" />
                <br/>
            </li>
            <li>
                <label for="message-input">Your Message</label>
                <textarea class="field-long" id="message-input" name="Message"></textarea>
            </li>
            <li>
                <label for="datepicker-input">Date</label>
                <input class="field-long" id="datepicker-input" name="Date" type="text" />
                <br/>
            </li>
            <li>
                <input type="submit" value="Submit" />
                <br/>
            </li>
        </ol>
    </form>
</section>

<script src="../client-side/bundles/contact/index.bundle.js"></script>

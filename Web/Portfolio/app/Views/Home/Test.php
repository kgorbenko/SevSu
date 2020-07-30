<link href="../client-side/bundles/home/test.bundle.css" rel="stylesheet" type="text/css" />

<section>
    <header>
        <h1>Engeneering graphics test</h1>
    </header>
    <p>All fields are required! Hover over fields to see the additional requirements.</p>
    <form action="someaction" method="POST">
        <ol>
            <li>
                <label>От чего зависит величина стрелок размерной линии?</label>
                <div class="radio-holder">
                    <label>От длины размерной линии</label>
                    <input id="1" name="question1" type="radio" value="1" />
                </div>
                <div class="radio-holder">
                    <label>От толщины линии контура изображения</label>
                    <input id="2" name="question1" type="radio" value="2" />
                </div>
            </li>
            <li>
                <label for="select-input">Какое назначение имеет тонкая сплошная линия?</label>
                <select id="select-input" name="question2" class="field-long">
                    <option value="1">Линии разграничения вида и разреза.</option>
                    <option value="2">Линии сечений.</option>
                    <option value="3">Линии штриховки.</option>
                </select>
            </li>
            <li>
                <label for="question3">Какие размеры являются рабочими?</label>
                <textarea class="field-long" id="question3" name="question3"></textarea>
            </li>
            <li>
                <label for="full-name-input">Full Name</label>
                <input class="field-long" id="full-name-input" name="full-name" type="text" />
                <br/>
            </li>
            <li>
                <label for="email-input">Email</label>
                <input class="field-long" id="email-input" name="email" type="email" />
                <br/>
            </li>
            <li>
                <label for="phone-input">Phone number</label>
                <input class="field-long" id="phone-input" name="phone" type="text" />
                <br/>
            </li>
            <li>
                <label for="message-input">Your Message</label>
                <textarea class="field-long" id="message-input" name="field4"></textarea>
            </li>
            <li>
                <input type="submit" value="Submit" />
                <br/>
            </li>
        </ol>
    </form>
</section>

<script src="../client-side/bundles/home/test.bundle.js"></script>
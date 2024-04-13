document.addEventListener("DOMContentLoaded", () => {
    let btnMenu = document.querySelector('.btn-menu')
    let nav = document.querySelector('nav')
    
    btnMenu.addEventListener('click', () => {
        btnMenu.classList.toggle('active')
        btnMenu.classList.toggle('fixed')

        nav.classList.toggle('active')
    })

    window.addEventListener('resize', () => {
        btnMenu.classList.remove('active')
        btnMenu.classList.remove('fixed')

        nav.classList.remove('active')
    })



    darkModeSwitch()
    select()
    search()
})


let forms = document.querySelectorAll('form')
let inputs = forms[0].querySelectorAll('input')

inputs.forEach(input => {
    if (input.dataset.val === 'true') {
        input.addEventListener('keyup', (e) => {
            switch (e.target.type) {
                case 'text':
                    textValidation(e, e.target.dataset.valMinlengthMin)
                    break

                case 'email':
                    emailValidation(e)
                    break

                case 'password':
                    if (e.target.name == 'Password')
                        passwordValidation(e)
                    if (e.target.name == 'ConfirmPassword')
                        confirmValidation(e)
                    break
            }
        })
    }
})

const handleValidationOutput = (isValid, e, text = "") => {
    let span = document.querySelector(`[data-valmsg-for="${e.target.name}"]`)

    if (isValid) {
        e.target.classList.remove('input-validation-error')
        span.classList.remove('field-validation-error')
        span.classList.add('field-validation-valid')
        span.innerHTML = ""

    } else {
        e.target.classList.add('input-validation-error')
        span.classList.add('field-validation-error')
        span.classList.remove('field-validation-valid')
        span.innerHTML = text
    }
}



const textValidation = (e, minLength = 1) => {
    if (e.target.value.length > 0)
        handleValidationOutput(e.target.value.length >= minLength, e, e.target.dataset.valMinlength)
    else
        handleValidationOutput(false, e, e.target.dataset.valRequired)
}




const emailValidation = (e) => {
    const regEx = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*\.[a-zA-Z]{2,}$/

    if (e.target.value.length > 0)
        handleValidationOutput(regEx.test(e.target.value), e, e.target.dataset.valRegex)
    else
        handleValidationOutput(false, e, e.target.dataset.valRequired)
}




const passwordValidation = (e) => {
    const regEx = /^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[\W_])(?!.*\s).{8,}$/


    if (e.target.value.length > 0)
        handleValidationOutput(regEx.test(e.target.value), e, e.target.dataset.valRegex)
    else
        handleValidationOutput(false, e, e.target.dataset.valRequired)
}

const confirmValidation = (e) => {

    //let compareTo = document.getElementById(e.target.dataset.valEqualtoOther)
    let compareTo = document.querySelector(e.target.dataset.valEqualtoOther)

    if (e.target.value.length > 0)
        handleValidationOutput(e.target.value === compareTo.value, e, e.target.dataset.valEqualto)
    else
        handleValidationOutput(false, e, e.target.dataset.valRequired)

}

function darkModeSwitch() {

    try {

        let sw = document.querySelector('#switch-mode')
        sw.addEventListener('change', function () {
            let mode = this.checked ? 'dark' : 'light'

            localStorage.setItem('mode', mode)
            sessionStorage.setItem('mode', mode)

            fetch(`/sitesettings/theme?mode=${mode}`)
                .then(res => {
                    if (res.ok)
                        window.location.reload()
                    else
                        console.log('unable to switch theme mode')
                })
        })
    }
    catch { }



}

function select() {
    try {
        
        let select = document.querySelector('.select')
        let selected = select.querySelector('.selected')
        let selectOptions = select.querySelector('.select-options')

        selected.addEventListener('click', function () {
            selectOptions.style.display = (selectOptions.style.display === 'block') ? 'none' : 'block'
        })

        let options = selectOptions.querySelectorAll('.option')
        options.forEach(function (option) {
            option.addEventListener('click', function () {
                selected.innerHTML = this.textContent
                selectOptions.style.display = 'none'
                selected.setAttribute("data-value", this.getAttribute("data-value"))
               updateCoursesByFilter()
            })
        })

    }
    catch {  }
}

function search() {
    try {

        document.querySelector('#searchQuery').addEventListener('keyup', function () {
            updateCoursesByFilter()
        })
    }
    catch { }


}

function updateCoursesByFilter() {
    const searchQuery = document.querySelector('#searchQuery').value
    const category = document.querySelector('.select .selected').getAttribute('data-value') || 'all'
    const url = `/courses/index?category=${encodeURIComponent(category)}&searchQuery=${encodeURIComponent(searchQuery)}`

    console.log(url)

    fetch(url)
        .then(res => res.text())
        .then(data => {
            const parser = new DOMParser()
            const dom = parser.parseFromString(data, 'text/html')
            document.querySelector('.items').innerHTML = dom.querySelector('.items').innerHTML

            //const pagination = dom.querySelector('.pagination') ? dom.querySelector('.pagination').innerHTML : ''
            //document.querySelector('.pagination').innerHTML = pagination

        })
}

document.addEventListener('DOMContentLoaded', function () {

    handleProfileImageUpload()

})



function handleProfileImageUpload() {
    try {

        let fileUploader = document.querySelector('#fileUploader')
        if (fileUploader != undefined) {
            fileUploader.addEventListener('change', function () {
                if (this.files.length > 0) {
                    this.form.submit()
                }
            })
        }

    }
    catch { }
}


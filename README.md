# 👨‍⚕️ Emergency Medical Service 👨‍⚕️

[![forthebadge](https://forthebadge.com/images/badges/fuck-it-ship-it.svg)](https://forthebadge.com)
[![forthebadge](https://forthebadge.com/images/badges/built-with-love.svg)](https://forthebadge.com)

## 💻 Login do systému 💻

> - #### Pro přihlášení do systému stačí do první kolonky zadat E-mail doktora a do druhé heslo.
> - #### Po zadání hesla stačí kliknout na tlačítko Login.

## 🏥 UI Webové aplikace 🏥

> - #### V horní části stránky se nachází navigační menu.
> - #### Celé UI je uděláno v co nejjednodušším stylu.

## 💾 Zobrazení dat 💾

> - #### Většinu webové stránky zabírá zobrazení dat.
> - #### Pro zobrazení vámi chtěných dat stačí kliknout v navigačním menu co chcete zobrazit.

```c#
    [HttpGet]
    public IActionResult Index()
    {
        string cookie = Request.Cookies["doctorId"];
        if (string.IsNullOrEmpty(cookie))
        {
            LoginModel loginModel = new LoginModel();
            return View(loginModel);
        }

        return RedirectToAction("Responds");
    }
    
    [HttpPost]
    public IActionResult Index(LoginModel loginModel)
    {
        var doctor = _service.GetAllDoctors().GetAwaiter().GetResult()
            .FirstOrDefault(x => x.Email == loginModel.Email && x.Password == loginModel.Password);

        if (doctor != null)
        {
            Response.Cookies.Append("doctorId", doctor.DoctorId.ToString());
            return RedirectToAction("Responds");
        }
        else
        {
            return RedirectToAction("Error");
        }
    }
```

## ➕ Přidání dat ➕

> - #### Pro přidání vámi určených dat stačí kliknout na tlačítko **New** v horní částí stránky hned pod navigačním menu.
> - #### Vždy ve které části jste (Responds, Doctors...), tak tyto data přidáváte.

## 📋 Úprava dat 📋

> - #### Pro úpravu dat stačí kliknout v určitém řádku na tlačítko **Edit**

## ❌ Smazání dat ❌

> - #### Pro smazání dat stačí kliknout v určitém řádku na tlačítko **Delete**

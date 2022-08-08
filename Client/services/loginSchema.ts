import * as Yup from "yup";

const loginSchema = Yup.object({
  email: Yup.string()
    .required("ایمیل نمیتواند خالی باشد")
    .email("یک ایمیل معتبر وارد کنید")
    .max(100, "ایمیل نمیتواند بیشتر از 100 کاراکتر باشد"),
  password: Yup.string()
    .required("کلمه عبور نمیتواند خالی باشد")
    .min(6, "کلمه عبور باید حداقل 6 رقم باشد"),
});

export default loginSchema;

import * as Yup from "yup";

const loginSchema = Yup.object({
  phoneNumber: Yup.string()
    .required("شماره موبایل نمیتواند خالی باشد")
    .min(11, "شماره موبایل نمیتواند کمتر از 11 عدد باشد")
    .max(11, "شماره موبایل نمیتواند بیشتر از 11 عدد باشد")
    .matches(/^09\d*$/, "لطفا شماره معتبر وارد کنید"),
  password: Yup.string()
    .required("کلمه عبور نمیتواند خالی باشد")
    .min(6, "کلمه عبور باید حداقل 6 رقم باشد"),
});

export default loginSchema;

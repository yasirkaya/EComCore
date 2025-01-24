import { configureStore, combineReducers } from "@reduxjs/toolkit";
import { persistStore, persistReducer } from "redux-persist";
import storage from "redux-persist/lib/storage"; // localStorage için
import cartReducer from "./slices/cartSlice";
import authReducer from "./slices/authSlice"; // Auth için reducer'ınız (varsa)


const authPersistConfig = {
  key: "auth",
  storage,
  whitelist: ["token", "user"], // Sadece token ve user state'lerini persist edeceğiz
};

const cartPersistConfig = {
  key: "cart",
  storage,
  whitelist: ["cart"],
};

// Root Reducer
const rootReducer = combineReducers({
  cart: persistReducer(cartPersistConfig, cartReducer),
  auth: persistReducer(authPersistConfig, authReducer), // Auth reducer'ını persist ettik
});

// Redux Store
const store = configureStore({
  reducer: rootReducer,
  devTools: process.env.NODE_ENV !== "production", // Sadece geliştirme modunda DevTools
});

// `persistor` öğesini export etmeyi unutmayın
const persistor = persistStore(store);

export { store, persistor };

// Redux store'un türlerini export edin
export type RootState = ReturnType<typeof rootReducer>;
export type AppDispatch = typeof store.dispatch;
